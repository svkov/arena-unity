using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuState;
    public GameObject loadingTextPanel;

    MenuStateHandler menuStateHandler;

    void Start()
    {
        menuStateHandler = menuState.GetComponent<MenuStateHandler>();
    }

    public void NewGame()
    {
        menuStateHandler.SetState(MenuState.LoadCharacter);
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void HighScores()
    {
        Debug.Log("High Scores");
    }

    void HideButtons()
    {
        gameObject.SetActive(false);
    }

    void ShowLoadingTextPanel()
    {
        loadingTextPanel.SetActive(true);
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Arena");
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading..." + asyncLoad.progress);
            loadingTextPanel.GetComponent<LoadingText>().SetProgress(asyncLoad.progress);
            yield return null;
        }
    }
}
