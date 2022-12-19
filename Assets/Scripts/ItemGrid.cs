using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    RectTransform GridRectTransform;

    //Maybe use a betterway to get screen size
    [SerializeField]
    Canvas NativeSizeCanvas;

    [SerializeField]
    Canvas ScaledSizeCanvas;

    // If your canvas is scales with screensize
    // use referace pixel per unit and not image width and height
    float TileSizeWidth;
    float TileSizeHeight;
    float ReferancePixelPerUnit = 100;

    private void Start()
    {
        GridRectTransform = GetComponent<RectTransform>();
        RectTransform NativeCanvasRect = NativeSizeCanvas.GetComponent<RectTransform>();
        RectTransform ScaledCanvasRect = ScaledSizeCanvas.GetComponent<RectTransform>();

        TileSizeWidth = Screen.width / ScaledCanvasRect.rect.width;
        TileSizeWidth = TileSizeWidth * ReferancePixelPerUnit;
        // When set to fit width, height and with are the same
        TileSizeHeight = TileSizeWidth;
        //Debug.Log("tile width " + TileSizeWidth + " tile height " + TileSizeHeight);
    }

    Vector2 PositionOnTheGrid = new Vector2();
    Vector2Int TileGridPosition = new Vector2Int();

    public Vector2Int GetTileGridPosition(Vector2 MousePosition)
    {
        //Debug.Log("mouse position " + MousePosition.x + "   " + MousePosition.y);
        PositionOnTheGrid.x = MousePosition.x - GridRectTransform.position.x;
        PositionOnTheGrid.y = MousePosition.y - GridRectTransform.position.y;

        TileGridPosition.x = (int)(PositionOnTheGrid.x / TileSizeWidth);
        TileGridPosition.y = (int)(PositionOnTheGrid.y / TileSizeHeight);

        return TileGridPosition;
    }
}
