using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{

    public void Exit()
    {
        GameObject.Find("Player").GetComponent<PlayerState>().SaveData();
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
