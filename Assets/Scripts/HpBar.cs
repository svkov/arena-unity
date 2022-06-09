using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMaxHealth(float newMaxHealth)
    {
        slider.maxValue = newMaxHealth;
        slider.value = newMaxHealth;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float hp)
    {
        slider.value = hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
