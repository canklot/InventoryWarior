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

    void Awake()
    {
        GridInteractInstance = GridInstance.GetComponent<GridInteract>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TileGridPosition = GridInstance.GetTileGridPosition(Input.mousePosition);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GridInteractInstance.PointerOverGrid == true)
                    {
                        Debug.Log("TouchPhase.Began");
                        PickUpItemCompound(TileGridPosition);
                    }
                    break;
                case TouchPhase.Moved:
                    Debug.Log("TouchPhase.Moved");
                    DragItemIcon();
                    break;
                case TouchPhase.Ended:
                    Debug.Log("TouchPhase.Ended");
                    PlaceItemCompound(TileGridPosition);
                    break;
            }
        }

        //Debug.Log("tile position " + SelectedItemGrid.GetTileGridPosition(Input.mousePosition));
    }

    void DragItemIcon()
    {
        if (SelectedItem != null)
        {
            SelectedItemRect.position = Input.mousePosition;
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
}
