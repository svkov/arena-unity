using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public float pickingRadius = 20;
    public LayerMask itemLayer;
    Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        TryPickUpItem();
    }

    void TryPickUpItem()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, pickingRadius, itemLayer);
            if (collider == null)
                return;
            if (collider.gameObject.TryGetComponent<ItemPicking>(out var item))
            {
                OnPickUp(item);
            }
            else if (collider.gameObject.TryGetComponent<Portal>(out var portal))
            {
                InteractPortal(portal);
            }

        }
    }

    public void OnPickUp(ItemPicking item)
    {
        bool success = inventory.Add(item.item);
        if (success)
        {
            Destroy(item.gameObject);
        }
    }

    void InteractPortal(Portal portal)
    {

        if (portal.isActivated)
        {
            portal.EnterPortal(gameObject);
        }
        else
        {
            Item soulStone = inventory.FindItemByName("Soul Stone");
            Debug.Log(soulStone);
            if (soulStone != null)
            {
                inventory.Remove(soulStone);
                portal.ActivatePortal();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, pickingRadius);
    }
}
