using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int size;
    public List<Item> inventory = new List<Item>();
    public GameObject itemObj;

    Hashtable idToItem = new Hashtable();

    void Awake()
    {
        var allItems = Resources.FindObjectsOfTypeAll<Item>();
        for(int i = 0; i < allItems.Length; i++)
        {
            idToItem.Add(allItems[i].id, allItems[i]);
        }
    }

    public bool Add(Item item)
    {
        if (HasFreeSpace())
        {
            inventory.Add(item);
            return true;
        }
        return false;
    }

    public bool Add(int id)
    {
        Item item = (Item) idToItem[id];
        if(item == null)
            return false;

        if(HasFreeSpace())
        {
            inventory.Add(item);
            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
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
