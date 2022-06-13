using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideProjectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject == null)
        {
            return;
        }

        if (collider.gameObject.TryGetComponent(out Projectile projectile))
        {
            if (projectile.owner == gameObject)
            {
                return;
            }
            Destroy(projectile.gameObject);

            var health = GetComponent<Health>();
            health.TakeDamage(projectile.owner);
        }
    }
}
