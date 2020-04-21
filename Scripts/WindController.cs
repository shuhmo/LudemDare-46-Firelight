using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    Vector2 _currentWindDir = Vector2.up;
    Vector2[] _possibleWindDirections;

    [SerializeField]
    Transform _windObject;
    [SerializeField]
    float _dirMultiplier = 10f;
    float _targetZRotation = 0f;
    
    [SerializeField]
    float _rotationSpeed = 5f;


    float _timerMax = 20f;
    float _currentTimer = 0f;
    

    private void Start()
    {

        _possibleWindDirections = new Vector2[4];
        _possibleWindDirections[0] = Vector2.up;
        _possibleWindDirections[1] = Vector2.down;
        _possibleWindDirections[2] = Vector2.left;
        _possibleWindDirections[3] = Vector2.right;

    }

    public void setNewRandomWindDirection() {
        Vector2 nextWindDir = _possibleWindDirections[Random.Range(0, _possibleWindDirections.Length - 1)];
        _currentWindDir = nextWindDir;

        if (nextWindDir == Vector2.up)
        {
            _targetZRotation = 0;

        }
        else if (nextWindDir == Vector2.down)
        {
            _targetZRotation = 180;
        }
        else if (nextWindDir == Vector2.left)
        {
            _targetZRotation = 90;
        }
        else {
            _targetZRotation = -90;
        }

    }

    private void rotateParticleSystem(float zAngle)
    {
        Vector3 rotation = Vector3.Lerp(_windObject.transform.rotation.eulerAngles, new Vector3(0, 0, zAngle), _rotationSpeed * Time.deltaTime);
        _windObject.transform.eulerAngles = new Vector3(0, 0, rotation.z);

    }

    private void Update()
    {
        _currentTimer += Time.deltaTime;

        if(_currentTimer >= _timerMax)
        {
            _currentTimer = 0;
            setNewRandomWindDirection();
        }
        rotateParticleSystem(_targetZRotation);
    }
    public Vector2 getCurrentWindDir() {
        return _currentWindDir;
    }




}
