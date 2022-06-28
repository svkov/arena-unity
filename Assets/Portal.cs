using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public bool isActivated;
    public GameObject graphics;
    public Sprite activatedSprite;
    public Sprite deactivatedSprite;
    public GameObject hint;

    SpriteRenderer sr;
    void Start()
    {
        sr = graphics.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(isActivated)
        {
            sr.sprite = activatedSprite;
        } else {
            sr.sprite = deactivatedSprite;
        }
    }

    public void ActivatePortal()
    {
        isActivated = true;
    }

    public void EnterPortal()
    {
        if(isActivated)
        {
            State.level_number++;
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Arena");

        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading..." + asyncLoad.progress);
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            hint.GetComponent<Hint>().ShowHint();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            hint.GetComponent<Hint>().HideHint();
        }
    }
}
