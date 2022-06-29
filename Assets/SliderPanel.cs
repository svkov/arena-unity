using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

abstract public class SliderPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int maxSliderValue;
    public GameObject sliderObject;
    public GameObject textOnSliderObject;

    string textOnHover;
    Slider slider;
    Text textOnSlider;

    string lastValueText;

    void Start()
    {
        slider = sliderObject.GetComponent<Slider>();
        textOnSlider = textOnSliderObject.GetComponent<Text>();
    }

    public void SetSliderValue(int value)
    {
        if(slider != null & textOnSlider != null)
        {
            slider.maxValue = maxSliderValue;
            slider.value = value;
            lastValueText = value.ToString() + "/" + maxSliderValue.ToString();
            textOnSlider.text = lastValueText;
        }
    }

    public void SetTextOnHover(string text)
    {
        textOnHover = text;
    }

    abstract public void UpdateUI(ActorStats actorStats);

    public void OnPointerEnter(PointerEventData eventData)
    {
        textOnSlider.text = textOnHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textOnSlider.text = lastValueText;
    }
}
