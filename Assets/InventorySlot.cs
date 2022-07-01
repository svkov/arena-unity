using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InventorySlot : MonoBehaviour, IPointerClickHandler 
{
    public Image icon;
    Item item;

    public void SetItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        Debug.Log("Use item");
    }

    public void DropItem()
    {
        Debug.Log("Drop item");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            UseItem();
         else if (eventData.button == PointerEventData.InputButton.Right)
            DropItem();
    }
}
