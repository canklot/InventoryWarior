using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridScript : MonoBehaviour
{
    // I dont like the name of this script
    // This script calculates on what grid coordinates the mouse is
    // Its competatible with a canvas that scale with screen size
    // Looks like it also works when its set to strech, anchor and pivot set to bottom mid
    [SerializeField]
    Canvas InventoryCanvas;
    RectTransform InventoryCanvasRect;

    float ReferancePixelPerUnit = 100;
    float TileWidthOnNativeCanvas,
        TileHeightOnNativeCanvas,
        TileWidthOnGridCanvas,
        TileHeightOnGridCanvas;

    float VerticalScaleCoefficient;

    Vector2 GridCoordinates = new Vector2();
    Vector2Int TileCoordinates = new Vector2Int();
    RectTransform GridRectTransform;

    InventoryItem[,] InventoryItemSlot;

    [SerializeField]
    InventoryItem InventoryItemPrefab;

    private void Start()
    {
        TileWidthOnGridCanvas = ReferancePixelPerUnit;
        TileHeightOnGridCanvas = ReferancePixelPerUnit;
        // Looks like based on what canvas you are and if its fixed size or scales coordinates and size can change between canvas
        GridRectTransform = GetComponent<RectTransform>();
        InventoryCanvasRect = InventoryCanvas.GetComponent<RectTransform>();
        // need better name TileSizeWidth. For what canvas it is
        VerticalScaleCoefficient = Screen.width / InventoryCanvasRect.rect.width;
        TileWidthOnNativeCanvas = VerticalScaleCoefficient * ReferancePixelPerUnit;
        // When set to fit width, height and with are the same
        TileHeightOnNativeCanvas = TileWidthOnNativeCanvas;
        //Debug.Log("tile width " + TileSizeWidth + " tile height " + TileSizeHeight);

        InventoryItemSlot = new InventoryItem[8, 4];
        InventoryItem ItemInstance = Instantiate(InventoryItemPrefab).GetComponent<InventoryItem>();
        PlaceItem(ItemInstance, 2, 2);
        ItemInstance = Instantiate(InventoryItemPrefab).GetComponent<InventoryItem>();
        PlaceItem(ItemInstance, 1, 1);
    }

    public Vector2Int GetTileGridPosition(Vector2 MousePosition)
    {
        //Debug.Log("mouse position " + MousePosition.x + "   " + MousePosition.y);
        GridCoordinates.x = MousePosition.x - GridRectTransform.position.x;
        GridCoordinates.y = MousePosition.y - GridRectTransform.position.y;

        TileCoordinates.x = (int)(GridCoordinates.x / TileWidthOnNativeCanvas);
        TileCoordinates.y = (int)(GridCoordinates.y / TileHeightOnNativeCanvas);

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

    public void PlaceItem(InventoryItem ItemToPlace, int posX, int posY)
    {
        Debug.Log("PlaceItem");
        RectTransform ItemToPlaceRect = ItemToPlace.GetComponent<RectTransform>();
        ItemToPlaceRect.SetParent(GridRectTransform, false);
        InventoryItemSlot[posX, posY] = ItemToPlace;

        Vector2 position = new Vector2();
        // Add half of the tile to center item
        position.x = posX * TileWidthOnGridCanvas + TileWidthOnGridCanvas / 2;
        position.y = posY * TileHeightOnGridCanvas + TileHeightOnGridCanvas / 2;

        ItemToPlaceRect.localPosition = position;

        // at the video he usses top left as anchor I use bottom left
    }

    public InventoryItem PickUpItem(int x, int y)
    {
        Debug.Log("PickUpItem");
        InventoryItem ToReturn = InventoryItemSlot[x, y];
        InventoryItemSlot[x, y] = null;
        return ToReturn;
    }
}
