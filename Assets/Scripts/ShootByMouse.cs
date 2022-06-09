using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootByMouse : MonoBehaviour
{
    
    public GameObject projectile;
    public float projectileRange;
    public float projectileSpeed;
    public float shootCooldownMax;
    float shootCooldown;
    void Start()
    {
        shootCooldown = shootCooldownMax;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        
        if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        if(Input.GetMouseButton(0) && shootCooldown <= 0)
        {
            shootCooldown = shootCooldownMax;
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var center = GetComponent< Renderer>().bounds.center;
        Vector3 direction = mousePos - center;
        direction.Normalize();
        Quaternion projRotation = Quaternion.FromToRotation(Vector3.up, direction);

        Projectile.SpawnProjectile(
            projectile,
            center,
            projRotation,
            gameObject,
            projectileSpeed,
            projectileRange,
            direction
        );
    }
}
