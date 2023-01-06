using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ItemData ItemDataInstance { get; private set; }

    GridScript InventoryGrid;

    internal void Set(ItemData ItemDataParam)
    {
        ItemDataInstance = ItemDataParam;
        GetComponent<Image>().sprite = ItemDataParam.ItemIcon;

        Vector2 size = new Vector2();
        size.x = ItemDataParam.Width * InventoryGrid.TileWidthOnGridCanvas;
        size.y = ItemDataParam.Height * InventoryGrid.TileHeightOnGridCanvas;
        GetComponent<RectTransform>().sizeDelta = size;
    }

    void Awake()
    {
        InventoryGrid = FindObjectOfType<GridScript>();
    }

    void Update() { }
}
