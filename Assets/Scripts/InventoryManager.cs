using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [HideInInspector]
    public ItemGrid SelectedItemGrid;

    InventoryItem SelectedItem;

    void Start()
    {
        SelectedItemGrid = null;
    }

    void Update()
    {
        if (SelectedItemGrid == null)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2Int TileGridPosition = SelectedItemGrid.GetTileGridPosition(Input.mousePosition);

            if (SelectedItem == null)
            {
                SelectedItem = SelectedItemGrid.PickUpItem(TileGridPosition.x, TileGridPosition.y);
            }
            else
            {
                SelectedItemGrid.PlaceItem(SelectedItem, TileGridPosition.x, TileGridPosition.y);
            }
        }
        Debug.Log("tile position " + SelectedItemGrid.GetTileGridPosition(Input.mousePosition));
    }
}
