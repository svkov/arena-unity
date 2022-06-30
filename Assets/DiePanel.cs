using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiePanel : MonoBehaviour
{
    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("Main Menu");
        PlayerPrefs.DeleteAll();
    }
}
