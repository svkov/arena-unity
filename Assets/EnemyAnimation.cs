using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public GameObject graphics;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        animator = graphics.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = graphics.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0.01f)
        {
            animator.SetBool("Walk", true);
        }
        else if(rb.velocity.magnitude < -0.01f)
        {
            animator.SetBool("Walk", false);
        }
        if(rb.velocity.y > 0.01f)
        {
            animator.SetBool("Back", true);
        }
        else if(rb.velocity.y < -0.01f)
        {
            animator.SetBool("Back", false);
        }
        if(animator.GetBool("Back"))
        {
            sr.flipX = false;
        }
    }
}
