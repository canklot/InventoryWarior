using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ItemDataClass ItemData { get; private set; }
    public Vector2Int OnGridPosition { get; set; }

    GridScript InventoryGrid;

    internal void Set(ItemDataClass ItemDataParam)
    {
        ItemData = ItemDataParam;
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
