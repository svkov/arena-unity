using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public Image image;

    public void ShowHint()
    {
        image.enabled = true;
    }

    public void HideHint()
    {
        image.enabled = false;
    }
}
