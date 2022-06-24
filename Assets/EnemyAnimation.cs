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
    EnemyAI ai;

    bool alive = true;

    void Start()
    {
        animator = graphics.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = graphics.GetComponent<SpriteRenderer>();
        healthObj = GetComponent<Health>();
        ai = GetComponent<EnemyAI>();
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
        Vector2 movement = ai.movement;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("Back", movement.y > 0);

        if(movement.x < -0.01f)
        {
            sr.flipX = false;
        } else if (movement.x > 0.01f)
        {
            sr.flipX = true;
        }

        if(healthObj.hp == 0 && alive)
        {
            alive = false;
            animator.SetTrigger("Die");
        }
    }
}
