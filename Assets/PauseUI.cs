using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    void Update()
    {
        // Unpause on ESC
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
