using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;

    public float speed;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedOfPath = false;

    public float attentionRadius;
    public Vector2 movement;

    Seeker seeker;
    Rigidbody2D rb;
    Health health;
    ActorStats stats;

    public float shootCooldownMax;
    float shootCooldown;

    public GameObject prefab;
    public float projectileRange;
    public float projectileSpeed;
    float attackSpeed;
    float attackCooldown;


    void Start()
    {
        shootCooldown = shootCooldownMax;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        stats = GetComponent<ActorStats>();
        speed = GetComponent<ActorStats>().GetMovementSpeed();
        UpdateAttackSpeed();
        InvokeRepeating(nameof(UpdatePath), 0, 0.5f);
    }

    void Update()
    {
        Attack();
    }

    void UpdatePath()
    {
        if (health.hp == 0)
            return;
        if (target == null | Vector3.Distance(transform.position, target.position) > attentionRadius)
            return;
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (health.hp == 0)
        {
            movement = new Vector2(0, 0);
            return;
        }

        if (path == null)
        {
            movement = new Vector2(0, 0);
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedOfPath = true;
            movement = new Vector2(0, 0);
            return;
        }
        else
        {
            reachedOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        movement = direction.normalized;

        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (rb.velocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    #region ShootToPlayer

    void Attack()
    {
        if (target == null || health.hp == 0)
            return;
        UpdateAttackCooldown();
        if (CanAttack())
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
        float distance = Vector3.Distance(target.transform.position, transform.position);
        return (attackCooldown == 0) && (distance < attentionRadius);
    }

    void ResetAttackCooldown()
    {
        attackCooldown = attackSpeed;
    }

    void ShootToPlayer()
    {
        var center = transform.position;
        var direction = target.transform.position - center;
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

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attentionRadius);
    }

    #endregion ShootToPlayer
}
