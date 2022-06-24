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

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        speed = GetComponent<ActorStats>().GetMovementSpeed();
        InvokeRepeating(nameof(UpdatePath), 0, 0.5f);
    }

    void UpdatePath()
    {
        if(health.hp == 0)
            return;
        if(target == null | Vector3.Distance(transform.position, target.position) > attentionRadius)
            return;
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if(health.hp == 0)
            return;

        if(path == null)
            return;
        
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedOfPath = true;
            return;
        } else {
            reachedOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        movement = direction.normalized;

        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if(rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if(rb.velocity.x <= 0.01f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
