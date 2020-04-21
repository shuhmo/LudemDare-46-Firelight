using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    public void LoadNewGame() {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void LoadWinGameScreen() {
        // Load Win screen!
        SceneManager.LoadSceneAsync("WinEndScreen");
    }
    public void LoadLoseGameScreen() {
        // load lose screen
        SceneManager.LoadSceneAsync("LoseEndScreen");
    }
    public void QuitGame() {
        Application.Quit();
    }

}
