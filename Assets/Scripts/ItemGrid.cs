using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGrid : MonoBehaviour
{
    // This script calculates on what grid coordinates the mouse is
    // Its competatible with a canvas that scale with screen size
    // Looks like it also works when its set to strech, anchor and pivot set to bottom mid
    [SerializeField]
    Canvas InventoryCanvas;
    RectTransform InventoryCanvasRect;

    float TileSizeWidth;
    float TileSizeHeight;
    float ReferancePixelPerUnit = 100;

    Vector2 GridCoordinates = new Vector2();
    Vector2Int TileCoordinates = new Vector2Int();
    RectTransform GridRectTransform;

    InventoryItem[,] InventoryItemSlot;

    private void Start()
    {
        GridRectTransform = GetComponent<RectTransform>();
        InventoryCanvasRect = InventoryCanvas.GetComponent<RectTransform>();

        TileSizeWidth = Screen.width / InventoryCanvasRect.rect.width;
        TileSizeWidth = TileSizeWidth * ReferancePixelPerUnit;
        // When set to fit width, height and with are the same
        TileSizeHeight = TileSizeWidth;
        //Debug.Log("tile width " + TileSizeWidth + " tile height " + TileSizeHeight);
        ResizeGrid(600, 800);
    }

    public Vector2Int GetTileGridPosition(Vector2 MousePosition)
    {
        //Debug.Log("mouse position " + MousePosition.x + "   " + MousePosition.y);
        GridCoordinates.x = MousePosition.x - GridRectTransform.position.x;
        GridCoordinates.y = MousePosition.y - GridRectTransform.position.y;

        TileCoordinates.x = (int)(GridCoordinates.x / TileSizeWidth);
        TileCoordinates.y = (int)(GridCoordinates.y / TileSizeHeight);

        return TileCoordinates;
    }

    void ResizeGrid(int ResizeWidth, int ResizeHeight)
    {
        //In the video this function is init

        // Because grid is set to fit width you can only change how many tiles on top of each other by changing grid height
        // If you want to change number of horizontal tiles you need to chane gridcanvas width
        // Example: Referance pixel per unit on GridCanvas is 100 if you want 8 horizontal tiles set GridCanvas width to 800
        // I dont know if canvas height matters

        CanvasScaler InventoryCanvasScaler = InventoryCanvas.GetComponent<CanvasScaler>();
        // Change horizontal number of tiles
        InventoryCanvasScaler.referenceResolution = new Vector2(ResizeWidth, ResizeHeight);
        // Change vertical number of tiles
        GridRectTransform.sizeDelta = new Vector2(1, ResizeHeight);
    }
}
