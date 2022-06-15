using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public bool isPickingUp = false;
    Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        PickUp();
    }

    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isPickingUp = true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            isPickingUp = false;
        }
    }

    public bool OnPickUp(Item item)
    {
        isPickingUp = false;
        return inventory.Add(item);
    }
}
