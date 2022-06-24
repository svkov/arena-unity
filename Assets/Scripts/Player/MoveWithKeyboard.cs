using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithKeyboard : MonoBehaviour
{
    float speed;
    public Camera cam;
    public float minOrthographicSize = 5;
    public float maxOrthographicSize = 30;
    private float currentOrthographicSize = 20;
    public GameObject inventory;
    public GameObject graphics;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    Vector2 currentMove = new Vector2(0, 0);
    bool isLeft = false;

    void Start()
    {
        speed = GetComponent<ActorStats>().GetMovementSpeed();
        rb = GetComponent<Rigidbody2D>();
        sr = graphics.GetComponent<SpriteRenderer>();
        animator = graphics.GetComponent<Animator>();
    }

    void Update()
    {
        SetAnimation(currentMove);
        Zoom();
        ShowOrHideInventory();
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 movement;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x < -0.01f)
        {
            sr.flipX = true;
        }
        else if (movement.x > 0.01f)
        {
            sr.flipX = false;
        }
    }

    void SetAnimation(Vector2 move)
    {
        var currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (move.y > 0)
        {
            animator.SetBool("Back", true);
        }
        if (move.y < 0 || (move.magnitude > 0 && move.y == 0))
        {
            animator.SetBool("Back", false);
        }
        SetMoving(move);
        if (move.x < 0)
        {
            isLeft = true;
            sr.flipX = true;
        }
        if (move.x > 0)
        {
            isLeft = false;
            sr.flipX = false;
        }
        bool isAnimationBack = currentState.IsName("KnightWalkBack") || currentState.IsName("KnightIdleBack");
        if (isAnimationBack)
        {
            sr.flipX = false;
        }
        else if (isLeft)
        {
            sr.flipX = true;
        }
        if (sr.flipX)
        {
            Debug.Log("Flipped");
        }
    }

    void SetMoving(Vector2 move)
    {
        if (move.magnitude > 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void Zoom()
    {
        currentOrthographicSize -= Input.mouseScrollDelta.y;
        currentOrthographicSize = Mathf.Clamp(currentOrthographicSize, minOrthographicSize, maxOrthographicSize);
        cam.orthographicSize = currentOrthographicSize;
    }

    void ShowOrHideInventory()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
        }
    }
}
