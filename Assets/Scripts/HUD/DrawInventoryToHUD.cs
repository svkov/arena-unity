using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawInventoryToHUD : MonoBehaviour
{

    Inventory inventory;
    public GameObject inventorySlot;
    public GameObject slots;
    readonly List<GameObject> inventorySlots = new List<GameObject>();

    void Start()
    {
        inventory = GetComponent<Inventory>();
        InitHUD();
        DrawHUD();
        inventory.onInventoryChange.AddListener(DrawHUD);
    }
    void InitHUD()
    {
        for (int i = 0; i < inventory.size; i++)
        {
            GameObject slot = Instantiate(inventorySlot);
            inventorySlots.Add(slot);
            slot.transform.SetParent(slots.transform);
            var slotObject = inventorySlot.GetComponent<InventorySlot>();
            if (i < inventory.inventory.Count)
            {
                slotObject.SetItem(inventory.inventory[i]);
            }
            else
            {
                slotObject.ClearSlot();
            }

        }

    }

    public void DrawHUD()
    {
        for (int i = 0; i < inventory.inventory.Count; i++)
        {
            inventorySlots[i].GetComponent<InventorySlot>().SetItem(inventory.inventory[i]);
        }
        for (int i = inventory.inventory.Count; i < inventory.size; i++)
        {
            inventorySlots[i].GetComponent<InventorySlot>().ClearSlot();
        }
    }
}
