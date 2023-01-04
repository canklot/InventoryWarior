using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool PointerOverGrid { get; private set; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerOverGrid = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerOverGrid = false;
    }

    public void AccessTest()
    {
        Debug.Log("AccessTest");
    }
}
