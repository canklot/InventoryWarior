using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [HideInInspector]
    public ItemGrid SelectedItemGrid;

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

        Debug.Log("tile position " + SelectedItemGrid.GetTileGridPosition(Input.mousePosition));
    }
}
