using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchController : MonoBehaviour
{
    [SerializeField] private FireScript playerTorchFireScript;
    [SerializeField] private FireScript bonfireFireScript;
    [SerializeField] private float maxTorchFuelAmmount;

    private Warmth warmth;

    // Start is called before the first frame update
    private void Awake()
    {
        warmth = GetComponent<Warmth>();
    }

    private void Update()
    {
        if (playerTorchFireScript.getFuelAmount() < 3f)
        {
            warmth.SetTorch(false);
        }
    }
    // Update is called once per frame

    public void lightTorch(bool Torch)
    {
        if(bonfireFireScript.getFuelAmount() > maxTorchFuelAmmount - playerTorchFireScript.getFuelAmount())
        {
            float refuel = maxTorchFuelAmmount - playerTorchFireScript.getFuelAmount();
            warmth.SetTorch(true);
            GiveTorchFuel(refuel);
        }
    }
    public void GiveTorchFuel(float refuel)
    {

        playerTorchFireScript.addFuelAmount(refuel);
        bonfireFireScript.TakeFuel(refuel);
    }
}
