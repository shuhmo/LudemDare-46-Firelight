using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireGridObject : GridObject
{

    FireScript _fireSource;
    WindCover _windCover;


    private void Awake()
    {
        base.Awake();
        _fireSource = GetComponent<FireScript>();
        _windCover = GetComponent<WindCover>();
    }


    public override void OnGridObjectInteract(Player player)
    {
        if (player.tryRemoveWoodFromInventory(2))
        {
            _fireSource.addFuelAmount(_fireSource.woodToFireRatio());
            _fireSource.addFuelAmount(_fireSource.woodToFireRatio());
        }
        else if (player.tryRemoveWoodFromInventory(1)) {
            _fireSource.addFuelAmount(_fireSource.woodToFireRatio());
        }
       
    }

    public override void OnSecondaryGridObjectInteract(Player player)
    {
        _windCover.coverFromWind();
    }
    public override void OnThridGridObjectInteract(Player player) {
        player.LightTorch(true);
    }
}
