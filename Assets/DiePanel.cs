using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiePanel : MonoBehaviour
{

    public Text scoreText;

    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("Main Menu");
        PlayerPrefs.DeleteAll();
    }
}
