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

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
        InitHUD();
    }
    void InitHUD()
    {
        for(int i = 0; i < inventory.size; i++)
        {
            GameObject slot = Instantiate(inventorySlot);
            inventorySlots.Add(slot);
            slot.transform.SetParent(slots.transform);
        }

    }
    void Update()
    {
        DrawHUD();
    }

    void DrawHUD()
    {
        for(int i = 0; i < inventory.inventory.Count; i++)
        {
            Debug.Log(i);
            Transform iconTransform = inventorySlots[i].transform.Find("Icon");
            GameObject icon = iconTransform.gameObject;
            Image image = icon.GetComponent<Image>();
            image.sprite = inventory.inventory[i].icon;
        }
        for(int i = inventory.inventory.Count; i < inventory.size; i++)
        {
            Transform iconTransform = inventorySlots[i].transform.Find("Icon");
            GameObject icon = iconTransform.gameObject;
            Image image = icon.GetComponent<Image>();
            image.sprite = null;
        }
    }
}
