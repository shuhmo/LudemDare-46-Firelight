using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWoodInventory : MonoBehaviour
{
    private int _woodCount = 0;
    private int _maxWoodCount = 2;
    [SerializeField] Animator playerAnimator;


    public int GetWoodCount() {
        return _woodCount;
    }
    public void SetWoodCount(int amount) {
        _woodCount = amount;
    }
    public void AddWood(int addAmount) {
        _woodCount += addAmount;
        if (_woodCount > _maxWoodCount) {
            _woodCount = _maxWoodCount;
        }
        playerAnimator.SetInteger("WoodCount", _woodCount);
    }
    public bool hasWood(int amount) {
        if (_woodCount >= amount) {
            return true;
        }
        return false;
    }
    public void RemoveWood(int removeAmount) {
        _woodCount -= removeAmount;
        if (_woodCount < 0) {
            _woodCount = 0;
        }
        playerAnimator.SetInteger("WoodCount", _woodCount);
    }
    public bool hasSpaceInInventory() {
        if (_woodCount < _maxWoodCount) {
            return true;
        }
        return false;
    }


}
