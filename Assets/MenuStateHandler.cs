using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuStateHandler : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject loadCharacter;
    public GameObject loadingScreen;

    MenuState state;
    GameObject stateObject;

    void Start()
    {
        DeactivateAllStates();
        UpdateInternalState(MenuState.Main);
    }

    void DeactivateAllStates()
    {
        mainMenu.SetActive(false);
        loadCharacter.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public void SetState(MenuState newState)
    {
        if (newState == state)
            return;

        stateObject.SetActive(false);
        UpdateInternalState(newState);
    }

    private void UpdateInternalState(MenuState newState)
    {
        switch (newState)
        {
            case MenuState.Main:
                stateObject = mainMenu;
                break;
            case MenuState.LoadCharacter:
                stateObject = loadCharacter;
                break;
            case MenuState.LoadingScreen:
                stateObject = loadingScreen;
                break;
            case MenuState.Settings:
                break;
            case MenuState.HighScores:
                break;
            default:
                stateObject = mainMenu;
                break;
        }
        stateObject.SetActive(true);
        state = newState;
    }
}
