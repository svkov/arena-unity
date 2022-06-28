using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacterMenu : MonoBehaviour
{
    public Button load;
    public Button newGame;
    public Button back;
    public Text description;

    void Start()
    {
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
        Debug.Log("Load");
    }

    public void NewGame()
    {
        Debug.Log("New game");
    }

    public void Back()
    {
        Debug.Log("Back");
    }
}
