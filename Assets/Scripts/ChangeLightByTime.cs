using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ChangeLightByTime : MonoBehaviour
{
    public GameObject globalLight;
    Light2D dayAndLight;

    Light2D selfLight;

    // Start is called before the first frame update
    void Start()
    {
        globalLight = GameObject.Find("Global Light");
        dayAndLight = globalLight.GetComponent<Light2D>();
        selfLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        selfLight.intensity = 1 - dayAndLight.intensity;
    }
}
