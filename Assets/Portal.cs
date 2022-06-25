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

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = graphics.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
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
}
