using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int size;
    public List<Item> inventory = new List<Item>();
    public GameObject itemObj;

    Hashtable idToItem = new Hashtable();

    public UnityEvent onInventoryChange;

    void Awake()
    {
        var allItems = Resources.FindObjectsOfTypeAll<Item>();
        for(int i = 0; i < allItems.Length; i++)
        {
            idToItem.Add(allItems[i].id, allItems[i]);
        }
    }

    void Start()
    {
        if(onInventoryChange == null)
            onInventoryChange = new UnityEvent();
    }

    public bool Add(Item item)
    {
        if (HasFreeSpace())
        {
            inventory.Add(item);
            onInventoryChange.Invoke();
            return true;
        }
        return false;
    }

    public bool Add(int id)
    {
        Item item = (Item) idToItem[id];
        if(item == null)
            return false;
        return Add(item);
    }

    public void Remove(Item item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            onInventoryChange.Invoke();
        }
    }

    public bool HasFreeSpace()
    {
        return inventory.Count < size;
    }

    public Item FindItemByName(string itemName)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].name == itemName)
            {
                return inventory[i];
            }
        }
        return null;
    }

    public void Drop(Item item)
    {
        var newItem = Instantiate(itemObj, transform.position, Quaternion.identity);
        var itemPicking = newItem.GetComponent<ItemPicking>();
        itemPicking.graphics.GetComponent<SpriteRenderer>().sprite = item.icon;
        itemPicking.item = item;
        Remove(item);
    }

    public void DropAll()
    {
        while(inventory.Count > 0)
        {
            Drop(inventory[0]);
        }
    }

    public void RemoveAll()
    {
        while(inventory.Count > 0)
        {
            Remove(inventory[0]);
        }
    }
}
