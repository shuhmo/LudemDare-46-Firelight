using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject: MonoBehaviour
{

    bool _isInteractable;

    int _gridPositionX;
    int _gridPositionY;
    WorldGrid _worldGrid;

    protected void Awake()
    {
        _worldGrid = FindObjectOfType<WorldGrid>();
    }

    public void Start()
    {
        Vector2 gridPoint = _worldGrid.WorldPointToGridPoint(transform.position.x, transform.position.y);
        _worldGrid.SetWorldGridPoint((int)gridPoint.x, (int)gridPoint.y, this);
        //Debug.Log("GridObject set to point: " + gridPoint);
    }


    [SerializeField]
    bool _isObstacle = false;

    public bool getIsObstacle() {
        return _isObstacle;
    }

    public int getXPos() {
        return _gridPositionX;
        
    }
    public int getYPOs() {
        return _gridPositionY;
    }

    public bool getIsInteractable() {
        return _isInteractable;
    }

    public virtual void OnGridObjectInteract(Player player) {
        Debug.Log("No interaction element added!");
    }

    public virtual void OnSecondaryGridObjectInteract(Player player) {
        Debug.Log("No secondary interaction element added!");
    }

    public virtual void OnThridGridObjectInteract(Player player) {
        Debug.Log("No Thrid interaction element added!");
    }
}
