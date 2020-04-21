using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    [SerializeField] FuelController innerLightIntensity;
    [SerializeField] FuelController outerLightIntensity;
    [SerializeField] FlickerScript innerflicker;
    [SerializeField] FlickerScript outerflicker;

    public int _startingFuelAmount = 0;
    [SerializeField] bool _useStartingAmount;
    [SerializeField] private int woodToFuelRatio = 10;
    [SerializeField] WindCover windCover;
    private bool hasWindCover = false;

    private void Awake()
    {
        windCover = GetComponent<WindCover>();
        if (windCover != null) {
            hasWindCover = true;
        }
        
    }



    // Start is called before the first frame update
    private void Start()
    {
        if (_useStartingAmount) {
            setFuelAmount(_startingFuelAmount);
        }
        if (hasWindCover) {
            innerLightIntensity.setWindCover(windCover);
            outerLightIntensity.setWindCover(windCover);
        }

    }
    public float getFuelAmount()
    {
        return innerLightIntensity.GetFuelAmount();
    }

    public void addFuelAmount(float addedWoodAmount)
    {
        innerLightIntensity.addFuel(addedWoodAmount);
        outerLightIntensity.addFuel(addedWoodAmount);
    }
    public void setFuelAmount(float woodAmount)
    {
        innerLightIntensity.SetFuelAmount(woodAmount);
        outerLightIntensity.SetFuelAmount(woodAmount);

    }

    public void TakeFuel(float takenWoodAmount)
    {
        innerLightIntensity.TakeFuel(takenWoodAmount);
        outerLightIntensity.TakeFuel(takenWoodAmount);
    }

    public int woodToFireRatio()
    {
        return woodToFuelRatio;
    }
        
}
