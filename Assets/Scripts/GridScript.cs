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
    CanvasScaler InventoryCanvasScaler;

    float ReferancePixelPerUnit;
    int TileCountX,
        TileCountY;
    float TileWidthOnNativeCanvas,
        TileHeightOnNativeCanvas;
    public float TileWidthOnGridCanvas { get; private set; }
    public float TileHeightOnGridCanvas { get; private set; }

    public float VerticalScaleCoefficient { get; private set; }

    Vector2 GridCoordinates = new Vector2();
    Vector2Int TileCoordinates = new Vector2Int();
    RectTransform GridRectTransform;

    InventoryItem[,] InventoryItemSlot;

    [SerializeField]
    InventoryItem InventoryItemPrefab;

    private void Awake()
    {
        InventoryCanvasScaler = InventoryCanvas.GetComponent<CanvasScaler>();
        GridRectTransform = GetComponent<RectTransform>();
        InventoryCanvasRect = InventoryCanvas.GetComponent<RectTransform>();
    }

    private void Start()
    {
        ReferancePixelPerUnit = InventoryCanvasScaler.referencePixelsPerUnit;
        TileWidthOnGridCanvas = ReferancePixelPerUnit;
        TileHeightOnGridCanvas = ReferancePixelPerUnit;

        VerticalScaleCoefficient = Screen.width / InventoryCanvasRect.rect.width;
        TileWidthOnNativeCanvas = VerticalScaleCoefficient * ReferancePixelPerUnit;
        // When set to fit width, height and with are the same
        TileHeightOnNativeCanvas = TileWidthOnNativeCanvas;
        TileCountX = (int)(InventoryCanvasScaler.referenceResolution.x / ReferancePixelPerUnit);
        TileCountY = (int)(GridRectTransform.rect.height / ReferancePixelPerUnit);
        InventoryItemSlot = new InventoryItem[TileCountX, TileCountY];
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

    public bool PlaceItem(InventoryItem ItemToPlace, int posX, int posY)
    {
        Debug.Log("PlaceItem");
        if (BoundryCheck(posX, posY, ItemToPlace.ItemDataInstance.Width, ItemToPlace.ItemDataInstance.Height) == false)
        {
            return false;
        }
        RectTransform ItemToPlaceRect = ItemToPlace.GetComponent<RectTransform>();
        ItemToPlaceRect.SetParent(GridRectTransform, false);

        for (int x = 0; x < ItemToPlace.ItemDataInstance.Width; x++)
        {
            for (int y = 0; y < ItemToPlace.ItemDataInstance.Height; y++)
            {
                InventoryItemSlot[posX + x, posY + y] = ItemToPlace;
            }
        }
        ItemToPlace.OnGridPosition = new Vector2Int(posX, posY);

        Vector2 position = new Vector2();
        // Add half of the tile to center item
        position.x = posX * TileWidthOnGridCanvas;
        position.y = posY * TileHeightOnGridCanvas;

        ItemToPlaceRect.localPosition = position;

        // at the video he usses top left as anchor I use bottom left

        return true;
    }

    public InventoryItem PickUpItem(int x, int y)
    {
        InventoryItem ToReturn = InventoryItemSlot[x, y];
        if (ToReturn == null)
        {
            return null;
        }
        for (int ix = 0; ix < ToReturn.ItemDataInstance.Width; ix++)
        {
            for (int iy = 0; iy < ToReturn.ItemDataInstance.Height; iy++)
            {
                InventoryItemSlot[ToReturn.OnGridPosition.x + ix, ToReturn.OnGridPosition.y + iy] = null;
            }
        }
        Debug.Log("PickUpItem");

        return ToReturn;
    }

    bool PositionCheck(int posX, int posY)
    {
        if (posX < 0 || posY < 0)
        {
            return false;
        }
        if (posX >= TileCountX || posY >= TileCountY)
        {
            return false;
        }
        return true;
    }

    bool BoundryCheck(int posX, int posY, int width, int height)
    {
        if (PositionCheck(posX, posY) == false)
        { // Check if mouse below grid coordinates
            return false;
        }

        if (PositionCheck(posX + width - 1, posY + height - 1) == false)
        { // Substract 1 because coordinates start from 0 but size starts from 1
            return false;
        }
        return true;
    }
}
