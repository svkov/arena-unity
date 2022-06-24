using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public GameObject graphics;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Health healthObj;

    bool alive = true;

    void Start()
    {
        animator = graphics.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = graphics.GetComponent<SpriteRenderer>();
        healthObj = GetComponent<Health>();
    }

    void Update()
    {
        if(alive)
        {
            PlayAnimation();
        }
    }

    void PlayAnimation()
    {
        Vector2 movement = rb.velocity.normalized;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("Back", movement.y > 0);

        if(movement.x < -0.01f)
        {
            sr.flipX = true;
        } else if (movement.x > 0.01f)
        {
            sr.flipX = false;
        }

        if(healthObj.hp == 0 && alive)
        {
            alive = false;
            animator.SetTrigger("Die");
        }
    }
}
