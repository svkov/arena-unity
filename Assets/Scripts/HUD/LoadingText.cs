using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingText : MonoBehaviour
{
    public GameObject textField;

    public void SetProgress(float progress)
    {
        int progressPercent = (int)progress * 100;
        textField.GetComponent<Text>().text = "Loading..." + progressPercent.ToString() + "%";
    }
}
