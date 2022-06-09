using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithKeyboard : MonoBehaviour
{
    public float speed;
    public Camera cam;
    public float minOrthographicSize = 5;
    public float maxOrthographicSize = 30;
    private float currentOrthographicSize = 10;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Zoom();
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
        }
        if (Input.GetKey(KeyCode.S))
        {
            move += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += Vector2.right;
        }
        rb.velocity = speed * move;
    }

    void Zoom()
    {
        currentOrthographicSize -= Input.mouseScrollDelta.y;
        currentOrthographicSize = Mathf.Clamp(currentOrthographicSize, minOrthographicSize, maxOrthographicSize);
        cam.orthographicSize = currentOrthographicSize;
    }
}
