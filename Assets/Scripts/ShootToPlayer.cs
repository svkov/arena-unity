using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToPlayer : MonoBehaviour
{

    public GameObject prefab;
    public float projectileRange;
    public float projectileSpeed;
    public float shootCooldownMax;
    float shootCooldown;
    GameObject player;

    void Start()
    {
        shootCooldown = shootCooldownMax;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        } else {
            shootCooldown = shootCooldownMax;
            Shoot();
        }
    }

    void Shoot()
    {
        var center = GetComponent<Renderer>().bounds.center;
        var direction = player.GetComponent<Renderer>().bounds.center - center;
        direction.Normalize();
        Quaternion projRotation = Quaternion.FromToRotation(Vector3.up, direction);

        Projectile.SpawnProjectile(
            prefab,
            center,
            projRotation,
            gameObject,
            3,
            10,
            direction
        );
    }
}
