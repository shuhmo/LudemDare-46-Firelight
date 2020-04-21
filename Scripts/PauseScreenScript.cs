using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenScript : MonoBehaviour
{
    InputController _inputController;
    [SerializeField]
    GameObject _pauseMenu;
    bool _isPaused;


    private void Awake()
    {
        _inputController = FindObjectOfType<InputController>();
    }

    private void Start()
    {
        _inputController.OnPausePressed += TogglePause;
    }


    public void TogglePause() {

        if (!_isPaused)
        {
            _isPaused = true;
            PauseGame();

        }
        else {
            _isPaused = false;
            UnPauseGame();
        }

    }
    

    private void PauseGame() {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    
    }

    private void UnPauseGame() {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
