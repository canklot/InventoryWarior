using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    GridScript GridInstance;

    GridInteract GridInteractInstance;

    InventoryItem SelectedItem;
    RectTransform SelectedItemRect;
    Vector2Int TileGridPosition;

    [SerializeField]
    List<ItemData> Itemlist;

    [SerializeField]
    GameObject InventoryItemPrefab;

    [SerializeField]
    RectTransform GridRect;

    void Awake()
    {
        GridInteractInstance = GridInstance.GetComponent<GridInteract>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            TouchControls();
        }

        //Debug.Log("tile position " + SelectedItemGrid.GetTileGridPosition(Input.mousePosition));
    }

    private void TouchControls()
    {
        Touch touch = Input.GetTouch(0);
        TileGridPosition = GridInstance.GetTileGridPosition(Input.mousePosition);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                if (GridInteractInstance.PointerOverGrid == true)
                {
                    PickUpItemCompound(TileGridPosition);
                }
                break;
            case TouchPhase.Moved:
                DragItemIcon();
                break;
            case TouchPhase.Ended:
                PlaceItemCompound(TileGridPosition);
                break;
        }
    }

    void DragItemIcon()
    {
        if (SelectedItem != null)
        {
            SelectedItemRect.position = new Vector2(
                Input.mousePosition.x - SelectedItemRect.rect.width / 2,
                Input.mousePosition.y - SelectedItemRect.rect.height / 2
            );
        }
    }

    void PlaceItemCompound(Vector2Int TileGridPosition)
    {
        if (SelectedItem != null)
        {
            GridInstance.PlaceItem(SelectedItem, TileGridPosition.x, TileGridPosition.y);
            SelectedItem = null;
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
            }
        }
    }

    public void CreateRandomItem()
    {
        InventoryItem inventoryItemInstance = Instantiate(InventoryItemPrefab)
            .GetComponent<InventoryItem>();
        RectTransform InventoryItemRect = inventoryItemInstance.GetComponent<RectTransform>();
        SelectedItem = inventoryItemInstance;
        InventoryItemRect.SetParent(GridRect, false);
        int SelectedItemID = Random.Range(0, Itemlist.Count);
        inventoryItemInstance.Set(Itemlist[SelectedItemID]);
    }
}
