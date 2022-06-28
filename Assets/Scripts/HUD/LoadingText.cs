using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingText : MonoBehaviour
{
    public GameObject textField;
    bool loading = false;

    void Update()
    {
        if(gameObject.activeSelf && !loading)
        {
            loading = true;
            StartCoroutine(nameof(LoadGameScene));
        }
    }

    IEnumerator LoadGameScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Arena");
        while (!asyncLoad.isDone)
        {
            SetProgress(asyncLoad.progress);
            yield return null;
        }
    }

    public void SetProgress(float progress)
    {
        int progressPercent = (int)progress * 100;
        textField.GetComponent<Text>().text = "Loading..." + progressPercent.ToString() + "%";
    }
}
