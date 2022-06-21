using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public GameObject animatorObject;
    Animator animator;

    Rigidbody2D rb;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = animatorObject.GetComponent<Animator>();
        sr = animatorObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
        // if (rb.velocity.y >= 0.01f)
        // {
        //     animator.SetBool("Back", true);
        // }
        // else if (rb.velocity.y <= -0.01f)
        // {
        //     animator.SetBool("Back", false);
        // }
        // if(rb.velocity.x < 0 & animator.GetBool("Back"))
        // {
        //     animator.SetBool("Back", false);
        // }
        // if(animator.GetBool("Back"))
        // {
        //     sr.flipX = false;
        // }
    }
}
