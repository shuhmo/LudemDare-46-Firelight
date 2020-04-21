using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FuelController : MonoBehaviour
{
    [SerializeField] private bool usesFuel;
    [SerializeField] private bool isWarm;
    private float Radius;
    //BURN VASRIABLES
    [SerializeField] private float fuelAmount;
    [SerializeField] private float woodTickAmount;
    private float woodBurnMax;
    [SerializeField] private float lightMin;
    [SerializeField] private float lightMax;

     bool hasCover;
    [SerializeField] float windFuelCost;

    private float currentFuelAmount;
    private float pastFuelTime;
    private float currentFireTime;
    private float pastFireTime;

    private WindCover _windCover;

    [SerializeField] private float tickTime;

    //FLICKER VARIABLES

    Light2D lightSource;
    // Start is called before the first frame update;

    private void Awake()
    {
        lightSource = GetComponent<Light2D>();
    }
    void Start()
    {
        pastFuelTime = Time.time;
        pastFireTime = Time.time;
        woodBurnMax = fuelAmount;
    }

    // Update is called once per frame
    void Update()
    {
        FuelBurn();
        useFuel();
    }

    public void setWindCover(WindCover windCover) {
        _windCover = windCover;
        hasCover = true;
    }

    private void FuelBurn()
    {
        currentFuelAmount = Time.time;
        if (currentFuelAmount - pastFuelTime > tickTime && usesFuel)
        {
            pastFuelTime = currentFuelAmount;
            
            if (fuelAmount > 0)
            {
                float minusTickAmount = woodTickAmount;
                if (hasCover && !_windCover.isCovered()) {
                    minusTickAmount += windFuelCost;
                    //Debug.Log("Ticking for wind! blblag");
                }

                fuelAmount -= minusTickAmount;
            }
        }
    }

    private void useFuel()
    {
        currentFireTime = Time.time;
        if (currentFireTime - pastFireTime > tickTime && usesFuel)
            {
                lightSource.pointLightOuterRadius = Mathf.Lerp(lightMin, lightMax, fuelAmount / woodBurnMax);
                lightSource.pointLightInnerRadius = Radius * 1 / 10;
            }
    }

    public float GetRadius()
    {
        return lightSource.pointLightOuterRadius;
    }

    public void addFuel(float Ammount)
    {
        fuelAmount += Ammount;
    }
    public float GetFuelAmount()
    {
        return fuelAmount;
    }
    public bool IsWarm()
    {
        return isWarm;
    }
    public void TakeFuel(float Amount)
    {
        fuelAmount -= Amount;
    }
    public void SetFuelAmount(float Amount) {
        fuelAmount = Amount;
    }

}
