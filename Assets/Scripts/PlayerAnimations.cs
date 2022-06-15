using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public GameObject animatorObject;
    Animator animator;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = animatorObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            // animator.Play("KnightWalk");
            animator.SetBool("Moving", true);
        } else {
            animator.SetBool("Moving", false);
        }
    }
}
