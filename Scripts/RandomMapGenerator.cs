using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class RandomMapGenerator : MonoBehaviour
{
    GameObjectProvider _gameObjectProvider;
    WorldGrid _worldGrid;
    GridObject[,] _mapGridObject;
    [SerializeField]
    Tilemap _tileMapGrid;


    [SerializeField]
    int _mapXSafeZone = 5;
    [SerializeField]
    int _mapYSafeZone = 5;

    [SerializeField]
    int _treeSpawnRate = 3;

    [SerializeField]
    int _rockSpawnRate = 1;

    [SerializeField]
    int _specialTileSpawnRate = 20;



    int _xSize;
    int _ySize;

    private void Awake()
    {
        _worldGrid = FindObjectOfType<WorldGrid>();
        _gameObjectProvider = GetComponent<GameObjectProvider>();
    }
    private void Start()
    {
        GenerateRandomMap();
    }
    public void GenerateRandomMap()
    {

        _mapGridObject = _worldGrid.getWorldGridObject();
        _xSize = _worldGrid.getMapWidth();
        _ySize = _worldGrid.getMapHeight();

        Debug.Log($"(_ySize / 2) - _mapYSafeZone = {(_ySize / 2) - _mapYSafeZone}    ,    (_ySize / 2) + _mapYSafeZone) : {_ySize / 2 + _mapYSafeZone}");
        Debug.Log($"(_xSize / 2) - _mapXSafeZone = {(_xSize / 2) - _mapXSafeZone}    ,    (_xSize / 2) + _mapXSafeZone : {(_xSize / 2) + _mapXSafeZone}");


        generateGroundTiles();
        RandomizeGridObjects();
    }

    private void generateGroundTiles() {
        for (int y = 0; y < _ySize; y++)
        {
            for (int x = 0; x < _xSize; x++)
            {

                bool spawnSpecialTile = (Random.Range(0, 100) <= _specialTileSpawnRate);
                Tile groundTile = new Tile();
                if (spawnSpecialTile)
                {
                    groundTile.sprite = _gameObjectProvider.GiveRandomGroundTileSprite();
                }
                else {
                    groundTile.sprite = _gameObjectProvider.GiveBasicGroundTile();
                }
                Vector2 spot = _worldGrid.GetWorldCoordinateFromGridPoint(x, y);
                _tileMapGrid.SetTile(new Vector3Int((int)spot.x, (int)spot.y, 5), groundTile);
                
            }
        }

    }
    private void RandomizeGridObjects() {
        
        for (int y = 0; y < _ySize; y++) {
            for (int x = 0; x < _xSize; x++)
            {
                if ((y >= (_ySize / 2) - _mapYSafeZone && y <= (_ySize / 2) + _mapYSafeZone) && (x >= (_xSize / 2) - _mapXSafeZone && x <= (_xSize / 2) + _mapXSafeZone))
                {
                    //no Trees 

                }
                else {

                    bool spawnTree = (Random.Range(0, 1000) <= _treeSpawnRate);
                    bool spawnRock = (Random.Range(0, 1000) <= _rockSpawnRate);
                    Vector2 spot = _worldGrid.GetWorldCoordinateFromGridPoint(x, y);

                    if (spawnRock)
                    {
                        Instantiate(_gameObjectProvider.GiveRandomObstacleObject(), new Vector3(spot.x, spot.y, 5), transform.rotation);
                    }
                    else if (spawnTree)
                    {

                        Instantiate(_gameObjectProvider.GiveRandomTreeObject(), new Vector3(spot.x, spot.y, 5), transform.rotation);
                    }
                    

                }
            }
        }
       // Debug.Log("Safespots :" + counter);

    }

  
    private void SetBonfire(int x, int y) { 
        


    }





}
