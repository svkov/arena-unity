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

            if(projectile == null)
                return;

            if(gameObject.layer != projectile.owner.layer)
            {
                var actorStats = GetComponent<ActorStats>();
                actorStats.TakeDamage(projectile.owner);
                Destroy(projectile.gameObject);
            }
            
        }
    }
}
