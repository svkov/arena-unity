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
    public GameObject pausePanel;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    ActorStats actorStats;

    void Start()
    {
        actorStats = GetComponent<ActorStats>();
        rb = GetComponent<Rigidbody2D>();
        sr = graphics.GetComponent<SpriteRenderer>();
        animator = graphics.GetComponent<Animator>();

        UpdateStats();
        actorStats.onChangeStats.AddListener(UpdateStats);
    }

    void Update()
    {
        PauseInput();        
        Zoom();
        ShowOrHideInventory();
    }

    void UpdateStats()
    {
        speed = actorStats.GetMovementSpeed();
    }

    void PauseInput()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(pausePanel.activeSelf)
            {
                UnpauseGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    void UnpauseGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
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
