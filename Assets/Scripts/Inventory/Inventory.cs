using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int size;
    public List<Item> inventory = new List<Item>();

    public bool Add(Item item)
    {
        if (HasFreeSpace())
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
}
