using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerWoodInventory _playerWoodInventory;
    private PlayerMovement _playerMovement;
    private TorchController _torchController;

    private void Awake()
    {
        _torchController = GetComponent<TorchController>();
        if (_torchController == null)
        {
            Debug.LogError("Player needs torchController!");
        }
        _playerWoodInventory = GetComponent<PlayerWoodInventory>();
        if (_playerWoodInventory == null) {
            Debug.LogError("Player needs PlayerWoodInventory!");
        }
        _playerMovement = GetComponent<PlayerMovement>();
        if (_playerMovement == null) {
            Debug.LogError("Player needs PlayerMovement!");
        }

    }

    public void addWoodToInventory(int amount) {
        _playerWoodInventory.AddWood(amount);
        Debug.Log("Added wood to inventory!");
        Debug.Log("Current Count: " + _playerWoodInventory.GetWoodCount());
    }
    public bool tryRemoveWoodFromInventory(int amount) {

        if (_playerWoodInventory.hasWood(amount)) {
            _playerWoodInventory.RemoveWood(amount);
            return true;
        }
        return false;
    }

    public bool hasSpaceInInventory(){


        return _playerWoodInventory.hasSpaceInInventory();
    }
    public void LightTorch(bool Torch)
    {
        _torchController.lightTorch(Torch);
    }

}
