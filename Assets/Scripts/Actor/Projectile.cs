using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float range;
    public Vector3 direction;

    public GameObject owner;
    private float movedDistance = 0;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 shift = speed * Time.deltaTime * direction;
        movedDistance += shift.magnitude;
        rb.MovePosition(transform.position + shift);

        if (movedDistance > range)
        {
            Destroy(gameObject, 0);
        }
    }

    public static void SpawnProjectile(
        GameObject prefab,
        Vector3 position,
        Quaternion rotation,
        GameObject owner,
        float speed,
        float range,
        Vector3 direction
    )
    {
        GameObject projectile = Instantiate(prefab, position, rotation);
        var proj = projectile.GetComponent<Projectile>();
        proj.direction = direction;
        proj.speed = speed;
        proj.range = range;
        proj.owner = owner;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == owner.layer)
            return;

        if(collider.gameObject != owner)
            Destroy(gameObject);
        
    }
}
