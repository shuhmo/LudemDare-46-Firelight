using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class PlayerLightController : MonoBehaviour
{
    private Warmth warmth;
    [SerializeField] private Light2D lightObject;
    private float maxLight;
    private float minLight;
    // Start is called before the first frame update
    private void Awake()
    {
        warmth = GetComponent<Warmth>();
    }

    private void Start()
    {
        maxLight = lightObject.pointLightOuterRadius;
        minLight = lightObject.pointLightInnerRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if (warmth.IsTorchActive())
        {
            if (lightObject.pointLightOuterRadius > minLight)
            {
                lightObject.pointLightOuterRadius -= Time.deltaTime;
            }
        }
        else
        {
            if (lightObject.pointLightOuterRadius < maxLight)
            {
                lightObject.pointLightOuterRadius += Time.deltaTime * 10;
            }
        }
    }
}