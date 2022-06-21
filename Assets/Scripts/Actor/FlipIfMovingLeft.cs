using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipIfMovingLeft : MonoBehaviour
{
    public GameObject spriteObject;
    Rigidbody2D rb;
    SpriteRenderer sr;

    bool isFlipped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = spriteObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(rb.velocity.x <= -0.01)
        {
            isFlipped = true;
            sr.flipX = isFlipped;
        } else if (rb.velocity.x >= 0.01)
        {
            isFlipped = false;
            sr.flipX = isFlipped;
        }


        
    }
}
