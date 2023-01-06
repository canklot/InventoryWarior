using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    ItemData ItemDataInstance;

    internal void Set(ItemData ItemDataParam)
    {
        ItemDataInstance = ItemDataParam;
        GetComponent<Image>().sprite = ItemDataParam.ItemIcon;
    }

    void Start() { }

    void Update() { }
}
