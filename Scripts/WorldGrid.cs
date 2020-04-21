using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
   
    private GridObject[,] _worldGrid;

    

    [SerializeField]
    int _xSize;
    [SerializeField]
    int _ySize;

    private void Awake()
    {
        _worldGrid = new GridObject[_xSize, _ySize];
    }


    public GridObject[,] getWorldGridObject() {
        return _worldGrid;
    }

    public int getMapHeight() {
        return _ySize;
    }

    public int getMapWidth() {
        return _xSize;
    }

    public bool CheckIfPointInGrid(int x, int y) {
        if (x <= _xSize - 1 && x >= 0 && y <= _ySize && y > 0) {
            return true;
        }

        return false;
    }

    public bool IsValidMove(int nextPosX, int nextPosY) {

        if (CheckIfPointInGrid(nextPosX, nextPosY) && GetGridPoint(nextPosX, nextPosY).getIsObstacle())
        {
            return true;
        }
        return false;
    }


    public void SetGridPoint(int x, int y, GridObject gridObject) {

        if (CheckIfPointInGrid(x, y)) {
            _worldGrid[x, y] = gridObject;
        }
    }
    public void SetWorldGridPoint(int x, int y, GridObject gridObject) {

        if (CheckIfPointInGrid(x + _xSize / 2, y + _ySize / 2))
        {
            _worldGrid[x + _xSize / 2, y + _ySize /  2] = gridObject;
        }

    }
    public GridObject GetWorldGridPoint(int x, int y) {

        if (CheckIfPointInGrid(x + _xSize / 2, y + _ySize / 2))
        {
            return _worldGrid[x + _xSize / 2, y + _ySize / 2];
        }
        return null;
    }
    public Vector2 GetWorldCoordinateFromGridPoint(int x, int y) {
        return new Vector2(x - _xSize / 2, y - _ySize / 2);
    }

   
    public GridObject GetGridPoint(int x, int y) {

        if (CheckIfPointInGrid(x, y))
        {
            return _worldGrid[x, y];
        }
        return null;
    }

    public Vector2 WorldPointToGridPoint(float x, float y) {
        return new Vector2(Mathf.Floor(x), Mathf.Floor(y));
    }






}
