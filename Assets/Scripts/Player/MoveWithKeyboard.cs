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

    void Start()
    {
        speed = GetComponent<ActorStats>().GetMovementSpeed();
        rb = GetComponent<Rigidbody2D>();
        sr = graphics.GetComponent<SpriteRenderer>();
        animator = graphics.GetComponent<Animator>();
    }

    void Update()
    {
        Zoom();
        ShowOrHideInventory();
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 move = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            move += Vector2.up;
            animator.SetBool("Back", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            move += Vector2.down;
            animator.SetBool("Back", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            move += Vector2.left;
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += Vector2.right;
            sr.flipX = false;
        }
        rb.velocity = speed * move;
    }

    void Zoom()
    {
        currentOrthographicSize -= Input.mouseScrollDelta.y;
        currentOrthographicSize = Mathf.Clamp(currentOrthographicSize, minOrthographicSize, maxOrthographicSize);
        cam.orthographicSize = currentOrthographicSize;
    }

    void ShowOrHideInventory()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
        }
    }
}
