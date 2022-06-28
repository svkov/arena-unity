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
        if(IsCharacterExist())
        {
            menuStateHandler.SetState(MenuState.LoadCharacter);
        }
        else
        {
            menuStateHandler.SetState(MenuState.LoadingScreen);
        }
        
    }

    bool IsCharacterExist()
    {
        return PlayerPrefs.GetInt("stats_level", -1) != -1;
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

}
