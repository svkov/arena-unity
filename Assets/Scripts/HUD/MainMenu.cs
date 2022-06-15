using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject newGameButton;
    public GameObject highScoresButton;
    public GameObject settingsButton;
    public GameObject exitButton;

    public GameObject loadingTextPanel;

    public void NewGame()
    {
        HideButtons();
        ShowLoadingTextPanel();
        StartCoroutine(LoadYourAsyncScene());
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }

    public void HighScores()
    {
        Debug.Log("High Scores");
    }

    void HideButtons()
    {
        newGameButton.SetActive(false);
        settingsButton.SetActive(false);
        exitButton.SetActive(false);
        highScoresButton.SetActive(false);
    }

    void ShowLoadingTextPanel()
    {
        loadingTextPanel.SetActive(true);
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Arena");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading..." + asyncLoad.progress);
            loadingTextPanel.GetComponent<LoadingText>().SetProgress(asyncLoad.progress);
            yield return null;
        }
    }
}
