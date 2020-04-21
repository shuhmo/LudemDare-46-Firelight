using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warmth : MonoBehaviour
{
    private float shortestDistanceToFire;
    [SerializeField] private bool isTorchActive;
    private float fireDistance;
    private bool freezing;
    private float radius;
    private ColdCircle coldCircle;
    FuelController[] fireGameObjects;
    FuelController closestLight;
    // Start is called before the first frame update
    private void Awake()
    {
        coldCircle = GetComponent<ColdCircle>();
    }
    void Start()
    {
        fireGameObjects = RefrestBonfires();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTorchActive)
        {
            fireDistance = DistanceToFire(fireGameObjects);
        }
    }

    public FuelController[] RefrestBonfires()
    {
        FuelController[] intensityArray = FindObjectsOfType<FuelController>();
        return intensityArray;
    }

    private float DistanceToFire(FuelController[] listOfLightObjects)
    {
        shortestDistanceToFire = Mathf.Infinity;
        foreach (FuelController light in listOfLightObjects)
        {
            float distance = Vector2.Distance(light.gameObject.transform.position, transform.position);
            if (distance < shortestDistanceToFire && light.IsWarm())
            {
                shortestDistanceToFire = distance;
                closestLight = light;
            }
        }
        SetFreezing();
        return shortestDistanceToFire;
    }

    private void SetFreezing()
    {
        if (closestLight.GetRadius() * 0.75 < shortestDistanceToFire)
        {
            freezing = true;
        }
        else
        {
            freezing = false;
        }
    }
    public bool isFreezing()
    {
        return freezing;
    }
    public bool IsTorchActive()
    {
        return isTorchActive;
    }
    public void SetTorch(bool torch)
    {
        isTorchActive = torch;
    }

}
