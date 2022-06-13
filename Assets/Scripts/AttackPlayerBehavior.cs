using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerBehavior : MonoBehaviour
{

    public GameObject target;
    public GameObject prefab;

    public float projectileSpeed;
    public float projectileRange;


    public float attentionRadius = 20;

    Rigidbody2D rb;

    ActorStats stats;

    float attackSpeed;
    float attackCooldown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<ActorStats>();
        UpdateAttackSpeed();
    }

    void Update()
    {
        if(target == null)
            return;
        UpdateAttackCooldown();
        if(CanAttack())
        {
            ResetAttackCooldown();
            ShootToPlayer();
        }
    }

    void UpdateAttackSpeed()
    {
        attackSpeed = stats.GetAttackSpeed();
        attackCooldown = attackSpeed;
    }

    void UpdateAttackCooldown()
    {
        attackCooldown = Mathf.Clamp(attackCooldown - Time.deltaTime, 0, attackSpeed);
    }

    bool CanAttack()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);
        return (attackCooldown == 0) && (distance < attentionRadius);
    }

    void ResetAttackCooldown()
    {
        attackCooldown = attackSpeed;
    }

    void ShootToPlayer()
    {
        var center = transform.position;
        var direction = target.GetComponent<Renderer>().bounds.center - center;
        direction.Normalize();
        Quaternion projRotation = Quaternion.FromToRotation(Vector3.up, direction);

        Projectile.SpawnProjectile(
            prefab,
            center,
            projRotation,
            gameObject,
            projectileSpeed,
            projectileRange,
            direction
        );
    }
}
