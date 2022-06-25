using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithKeyboard : MonoBehaviour
{
    float speed;
    public Camera cam;
    public float minOrthographicSize;
    public float maxOrthographicSize;
    public float currentOrthographicSize;
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
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
            
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
        movement.Normalize();
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
        animator.SetBool("Back", movement.y > 0);
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
