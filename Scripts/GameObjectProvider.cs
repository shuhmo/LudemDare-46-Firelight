using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectProvider: MonoBehaviour
{
    [SerializeField]
    GameObject[] _treeGameObjects;
    [SerializeField]
    GameObject[] _obstacleGameObjects;
    [SerializeField]
    Sprite _basicGroundTile;
    [SerializeField]
    Sprite[] _groundTiles;
    [SerializeField]
    GameObject _bonfireGameObject;

    public GameObject GiveRandomTreeObject() {
        return _treeGameObjects[Random.Range(0, _treeGameObjects.Length )];
    }
    public GameObject GiveRandomObstacleObject() {
        return _obstacleGameObjects[Random.Range(0, _obstacleGameObjects.Length)];
    }

    public Sprite GiveBasicGroundTile() {
        return _basicGroundTile;
    }
    public Sprite GiveRandomGroundTileSprite() {
        return _groundTiles[Random.Range(0, _groundTiles.Length)];
    }
    public GameObject GetBonfireGameObject() {
        return _bonfireGameObject;
    }
    

   
}
