using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperiencePanel : MonoBehaviour
{
    public int maxExperience;
    public GameObject textObject;
    public GameObject sliderObject;
    public GameObject experienceTextObject;

    Text text;
    Slider slider;
    Text experienceText;

    void Start()
    {
        text = textObject.GetComponent<Text>();
        slider = sliderObject.GetComponent<Slider>();
        experienceText = experienceTextObject.GetComponent<Text>();
    }

    public void SetExp(int experience)
    {
        slider.maxValue = maxExperience;
        slider.value = experience;

        experienceText.text = experience.ToString() + "/" + maxExperience.ToString();
    }

    public void SetLevel(int level)
    {
        text.text = "Level: " + level.ToString();
    }
}
