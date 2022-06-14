using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipIfMovingLeft : MonoBehaviour
{
    public GameObject spriteObject;
    Rigidbody2D rb;
    SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = spriteObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        sr.flipX = rb.velocity.x < 0;
    }
}
