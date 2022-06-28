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
        if(slider != null & experienceText != null)
        {
            slider.maxValue = maxExperience;
            slider.value = experience;
            experienceText.text = experience.ToString() + "/" + maxExperience.ToString();
        }
    }

    public void SetLevel(int level)
    {
        if(text != null)
            text.text = "Level: " + level.ToString();
    }

    public void UpdateUI(ActorStats actorStats)
    {
        SetLevel(actorStats.level);
        maxExperience = actorStats.experienceToLevelUp;
        SetExp(actorStats.experience);
    }
}
