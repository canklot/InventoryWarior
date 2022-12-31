using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(ItemGrid))]
public class GridInteract
    : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerUpHandler,
        IPointerDownHandler
{
    [SerializeField]
    InventoryManager InventoryManagerInstanceToChange;

    [SerializeField]
    ItemGrid SelectedItemGridBackup;

    [SerializeField]
    TextMeshProUGUI DebugText;
    ItemGrid ItemGridInstance;

    private void Awake()
    {
        ItemGridInstance = GetComponent<ItemGrid>();
    }

    public void OnPointerEnter(PointerEventData eventData) { }

    public void OnPointerUp(PointerEventData eventData) { }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManagerInstanceToChange.SelectedItemGrid = null;
        Debug.Log("OnPointerExit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        if (EventSystem.current.IsPointerOverGameObject())
        {
            InventoryManagerInstanceToChange.SelectedItemGrid = ItemGridInstance;
            Debug.Log("Clicked on the UI. Not Null");
        }
    }

    // There is some problems witch touch input

    void Start() { }

    void Update() { }
}
