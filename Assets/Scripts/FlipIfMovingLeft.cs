using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipIfMovingLeft : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        sr.flipX = rb.velocity.x < 0;
    }
}
