using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{




    public delegate void SecondaryInteractionHandler();
    public event SecondaryInteractionHandler OnSecondaryInteractionPressed;

    public delegate void ThirdInteractionHandler();
    public event ThirdInteractionHandler OnThridInteractionPressed;

    public delegate void InteractionHandler();
    public event InteractionHandler OnInteractionPressed;

    public delegate void UpKeyHandler();
    public event UpKeyHandler OnUpKeyPressed;

    public delegate void UpKeyReleaseHandler();
    public event UpKeyReleaseHandler OnUpKeyReleased;

    public delegate void DownKeyHandler();
    public event DownKeyHandler OnDownKeyPressed;

    public delegate void DownKeyReleaseHandler();
    public event DownKeyReleaseHandler OnDownKeyReleased;

    public delegate void LeftKeyHandler();
    public event LeftKeyHandler OnLeftKeyPressed;

    public delegate void LeftKeyReleaseHandler();
    public event LeftKeyReleaseHandler OnLeftKeyReleased;

    public delegate void RightKeyHandler();
    public event RightKeyHandler OnRightKeyPressed;

    public delegate void RightKeyReleaseHandler();
    public event RightKeyReleaseHandler OnRightKeyReleased;

    public delegate void PaueseHandler();
    public event PaueseHandler OnPausePressed;
    


    float _inputVectorX;
    float _inputVectorY;


   

    private void Update()
    {
        _inputVectorX = 0;
        _inputVectorY = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnInteractionPressed?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            OnSecondaryInteractionPressed?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.F)) {
            OnThridInteractionPressed?.Invoke();
        }




        if (Input.GetKey(KeyCode.W))
        {
            _inputVectorY = 1;
            OnUpKeyPressed?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.W)) {
            OnUpKeyReleased?.Invoke();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _inputVectorY = -1;
            OnDownKeyPressed?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            OnDownKeyReleased?.Invoke();
        }


        if (Input.GetKey(KeyCode.A))
        {
            _inputVectorX = -1;
            OnLeftKeyPressed?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            OnLeftKeyReleased?.Invoke();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _inputVectorX = 1;
            OnRightKeyPressed?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            OnRightKeyReleased?.Invoke();
        }





        if (Input.GetKeyDown(KeyCode.Escape)){
            OnPausePressed?.Invoke();
        }
        
       
    }
    public Vector2 getInputVector() {
        return new Vector2(_inputVectorX, _inputVectorY);
    }
    public float getXAxis() {
        return _inputVectorX;
    }

    public float getYAxis() {
        return _inputVectorY;
    }
    public bool movementKeysPressed() {
        if (_inputVectorX != 0 || _inputVectorY != 0) {
            return true;
        }
        return false;
    }
    
   

}
