using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    // This script calculates on what grid coordinates the mouse is
    // Its competatible with a canvas that scale with screen size
    // Looks like it also works when its set to strech, anchor and pivot set to bottom mid
    [SerializeField]
    Canvas InventoryCanvas;

    float TileSizeWidth;
    float TileSizeHeight;
    float ReferancePixelPerUnit = 100;

    Vector2 GridCoordinates = new Vector2();
    Vector2Int TileCoordinates = new Vector2Int();
    RectTransform GridRectTransform;

    private void Start()
    {
        GridRectTransform = GetComponent<RectTransform>();
        RectTransform InventoryCanvasRect = InventoryCanvas.GetComponent<RectTransform>();

        TileSizeWidth = Screen.width / InventoryCanvasRect.rect.width;
        TileSizeWidth = TileSizeWidth * ReferancePixelPerUnit;
        // When set to fit width, height and with are the same
        TileSizeHeight = TileSizeWidth;
        //Debug.Log("tile width " + TileSizeWidth + " tile height " + TileSizeHeight);
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
}
