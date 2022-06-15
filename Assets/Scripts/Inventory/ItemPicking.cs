using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicking : MonoBehaviour
{
    public Item item;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent<PickUpItem>(out var pick))
        {
            if(pick.isPickingUp)
            {
                bool was_picked = pick.OnPickUp(item);
                if (was_picked)
                {
                    Destroy(gameObject);
                }
            }
            
        }

    }
}
