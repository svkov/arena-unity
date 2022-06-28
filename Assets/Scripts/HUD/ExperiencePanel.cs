using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExperiencePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int maxExperience;
    public GameObject textObject;
    public GameObject sliderObject;
    public GameObject experienceTextObject;

    Text text;
    Slider slider;
    Text experienceText;

    string lastExpirienceText;

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
            lastExpirienceText = experience.ToString() + "/" + maxExperience.ToString();
            experienceText.text = lastExpirienceText;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        experienceText.text = "EXP";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        experienceText.text = lastExpirienceText;
    }

    
}
