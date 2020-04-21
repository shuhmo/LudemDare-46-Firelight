using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlickerScript : MonoBehaviour
{
    private float currentFlickerTime;
    private float pastFlickerTime;
    [SerializeField] private float flickerSpeed;
    [SerializeField] private float minFlicker;
    [SerializeField] private float maxFlicker;

    //COLOR VARIABLES
    [SerializeField] private Color redLimit;
    [SerializeField] private Color yellowLimit;
    private float randomInterval;
    private float lastRandom;
    Light2D lightSource;
    [SerializeField] private bool flicker = true;

    // Start is called before the first frame update
    private void Awake()
    {
        lightSource = GetComponent<Light2D>();
    }
    void Start()
    {
        lastRandom = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        Flicker();
    }

    private void Flicker()
    {
        currentFlickerTime = Time.time;
        if (currentFlickerTime - pastFlickerTime > flickerSpeed && flicker)
        {
            randomInterval = Random.Range(lastRandom - 30, lastRandom + 30);
            if (randomInterval / 1000 > 1)
            {
                randomInterval = 950;
            }

            else if (randomInterval < 0)
            {
                randomInterval = 50;
            }

            pastFlickerTime = currentFlickerTime;
            lightSource.intensity = (Random.Range(minFlicker, maxFlicker));
            lightSource.color = Color.Lerp(redLimit, yellowLimit, randomInterval / 1000);
            lastRandom = randomInterval;
        }

    }
}
