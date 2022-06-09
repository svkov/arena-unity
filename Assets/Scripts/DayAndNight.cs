using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayAndNight : MonoBehaviour
{

    public bool isDay;
    public float intensityChangeCooldown;
    public float currentTime;
    Light2D light2d;

    void Start()
    {
        light2d = GetComponent<Light2D>();
        light2d.intensity = 1f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > intensityChangeCooldown)
        {
            currentTime = 0;
            if (isDay)
            {
                SetDay();
            }
            else
            {
                SetNight();
            }
        }
    }

    void SetDay()
    {
        if(light2d.intensity < 1)
        {
            IncreaseIntensity();
        }
    }

    void SetNight()
    {
        if (light2d.intensity > 0)
        {
            DecreaseIntensity();
        }
    }
    void IncreaseIntensity()
    {
        light2d.intensity += 0.1f;
    }

    void DecreaseIntensity()
    {
        light2d.intensity -= 0.1f;
    }
}
