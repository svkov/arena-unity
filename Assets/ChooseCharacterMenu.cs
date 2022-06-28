using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacterMenu : MonoBehaviour
{
    public GameObject menuState;
    public Text description;

    MenuStateHandler menuStateHandler;

    void Start()
    {
        menuStateHandler = menuState.GetComponent<MenuStateHandler>();
        UpdateCharacterPreview();
    }

    void UpdateCharacterPreview()
    {
        var level = PlayerPrefs.GetInt("stats_level");
        var realm = PlayerPrefs.GetInt("level_number");
        description.text = "Player\nLVL: " + level.ToString() + "\nRealm: " + realm.ToString();
    }

    public void LoadCharacter()
    {
        menuStateHandler.SetState(MenuState.LoadingScreen);
    }

    public void NewGame()
    {
        menuStateHandler.SetState(MenuState.LoadingScreen);
    }

    public void Back()
    {
        menuStateHandler.SetState(MenuState.Main);
    }
}
