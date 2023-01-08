using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    GridScript GridInstance;

    GridInteract GridInteractInstance;

    InventoryItem SelectedItem;
    RectTransform SelectedItemRect;
    Vector2Int TileGridPosition;

    [SerializeField]
    List<ItemDataClass> Itemlist;

    [SerializeField]
    GameObject InventoryItemPrefab;

    [SerializeField]
    RectTransform GridRect;

    Vector3 OldPosition;

    void Awake()
    {
        GridInteractInstance = GridInstance.GetComponent<GridInteract>();
    }

    void Update()
    {
        //Debug.Log("tile position " + SelectedItemGrid.GetTileGridPosition(Input.mousePosition));
    }

    void DragItemIcon()
    {
        if (SelectedItem != null)
        {
            SelectedItemRect.position = new Vector2(
                Input.mousePosition.x - (SelectedItemRect.rect.width * 0.25f * GridInstance.VerticalScaleCoefficient),
                Input.mousePosition.y - (SelectedItemRect.rect.height * 0.25f * GridInstance.VerticalScaleCoefficient)
            );
        }
    }

    void PlaceItemCompound(Vector2Int TileGridPosition)
    {
        if (SelectedItem != null)
        {
            bool PlaceSuccess = GridInstance.PlaceItem(SelectedItem, TileGridPosition.x, TileGridPosition.y);
            if (PlaceSuccess)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItemRect.position = OldPosition;
            }
        }
    }

    void PickUpItemCompound(Vector2Int TileGridPosition)
    {
        if (SelectedItem == null)
        {
            SelectedItem = GridInstance.PickUpItem(TileGridPosition.x, TileGridPosition.y);
            if (SelectedItem != null)
            {
                SelectedItemRect = SelectedItem.GetComponent<RectTransform>();
                OldPosition = SelectedItemRect.position;
            }
        }
    }

    public void CreateRandomItem()
    {
        InventoryItem inventoryItemInstance = Instantiate(InventoryItemPrefab).GetComponent<InventoryItem>();
        RectTransform InventoryItemRect = inventoryItemInstance.GetComponent<RectTransform>();
        SelectedItem = inventoryItemInstance;
        InventoryItemRect.SetParent(GridRect, false);
        int SelectedItemID = Random.Range(0, Itemlist.Count);
        inventoryItemInstance.Set(Itemlist[SelectedItemID]);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GridInteractInstance.PointerOverGrid == true)
        {
            TileGridPosition = GridInstance.GetTileGridPosition(Input.mousePosition);
            PickUpItemCompound(TileGridPosition);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragItemIcon();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TileGridPosition = GridInstance.GetTileGridPosition(Input.mousePosition);
        PlaceItemCompound(TileGridPosition);
    }
}
