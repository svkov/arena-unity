using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideProjectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent(out Projectile projectile))
        {
            if(projectile.owner == gameObject)
            {
                return;
            }
            Destroy(projectile.gameObject);
            if(projectile.owner.TryGetComponent(out DamageDeal dd))
            {
                var health = GetComponent<Health>();
                health.TakeDamage(dd.damage);
            }
        }
    }
}
