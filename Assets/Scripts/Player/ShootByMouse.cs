using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootByMouse : MonoBehaviour
{
    
    public GameObject projectile;
    public float projectileRange;
    public float projectileSpeed;
    public GameObject playerGraphics;

    Animator animator;
    SpriteRenderer sr;
    ActorStats actorStats;

    float shootCooldownMax;
    float shootCooldown;
    void Start()
    {
        animator = playerGraphics.GetComponent<Animator>();
        sr = playerGraphics.GetComponent<SpriteRenderer>();
        actorStats = GetComponent<ActorStats>();
        UpdateStats();
        actorStats.onChangeStats.AddListener(UpdateStats);
    }

    void Update()
    {
        Fire();
    }

    void UpdateStats()
    {
        shootCooldownMax = actorStats.GetAttackSpeed();
        shootCooldown = shootCooldownMax;
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
            animator.SetTrigger("Attack");
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        FlipIfNeeded(mousePos);
        var center = transform.position;
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

    void FlipIfNeeded(Vector3 mousePos)
    {
        if(mousePos.x < transform.position.x & !sr.flipX)
        {
            sr.flipX = true;
        } else if(mousePos.x > transform.position.x & sr.flipX)
        {
            sr.flipX = false;
        }
    }
}
