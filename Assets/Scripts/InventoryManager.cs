using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [HideInInspector]
    public ItemGrid SelectedItemGrid;

    InventoryItem SelectedItem;
    RectTransform SelectedItemRect;

    void Update()
    {
        DragItemIcon();

        if (SelectedItemGrid == null)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2Int TileGridPosition = SelectedItemGrid.GetTileGridPosition(Input.mousePosition);

            if (SelectedItem == null)
            {
                PickUpItemCompound(TileGridPosition);
            }
            else
            {
                PlaceItemCompound(TileGridPosition);
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
        SelectedItemGrid.PlaceItem(SelectedItem, TileGridPosition.x, TileGridPosition.y);
        SelectedItem = null;
    }

    void PickUpItemCompound(Vector2Int TileGridPosition)
    {
        SelectedItem = SelectedItemGrid.PickUpItem(TileGridPosition.x, TileGridPosition.y);
        if (SelectedItem != null)
        {
            SelectedItemRect = SelectedItem.GetComponent<RectTransform>();
        }
    }
}
