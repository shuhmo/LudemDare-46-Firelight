using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCover : MonoBehaviour
{
    WindController _windController;

    [SerializeField]
    GameObject[] _covers;
    GameObject _currentCover;
    int _currentCoverIndex = 0;
    Vector2 _currentCoveringDir;
    [SerializeField]
    GameObject _startingCover;
    private void Awake()
    {
        _windController = FindObjectOfType<WindController>();
    }

    private void Start()
    {
        _currentCover = _startingCover;
    }

    public void cycleNextCover() {
        _currentCover?.SetActive(false);
        _currentCover = _covers[_currentCoverIndex % _covers.Length];
        _currentCover.SetActive(true);
        _currentCoverIndex++;
    }
    public void coverFromWind() {


        Vector2 currentWindDir = _windController.getCurrentWindDir();
        GameObject nextCover;
        if (currentWindDir == Vector2.up)
        {
            nextCover = _covers[2];
            _currentCoveringDir = Vector2.up;

        }
        else if (currentWindDir == Vector2.right)
        {
            nextCover = _covers[3];
            _currentCoveringDir = Vector2.right;
        }
        else if (currentWindDir == Vector2.down)
        {
            nextCover = _covers[0];
            _currentCoveringDir = Vector2.down;
        }
        else {
            nextCover = _covers[1];
            _currentCoveringDir = Vector2.left;
        }


        _currentCover?.SetActive(false);
        _currentCover = nextCover;
        _currentCover.SetActive(true);
    }

    public bool isCovered() {
        Vector2 currentWindDir = _windController.getCurrentWindDir();

        if (currentWindDir == _currentCoveringDir)
        {
            return true;
            

        }
        return false;
        
       

    }

    

}

    




