using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    [SerializeField]
    float _startingTime = 300f;

    float timerLeft;
    [SerializeField] private Text text;
    private PlayerHealth health;
    GameStateManager _gameStateManager;
    // Update is called once per frame


    private void Awake()
    {
        _gameStateManager = GetComponent<GameStateManager>();
        health = FindObjectOfType<PlayerHealth>();
    }
    private void Start()
    {
        timerLeft = _startingTime;
    }
    void Update()
    {
        if (!health.GetDead())
        {
            timerLeft -= Time.deltaTime;
            text.text = string.Format("{0:0}", timerLeft);
            if (timerLeft <= 0)
            {

                _gameStateManager.LoadWinGameScreen();

            }
        }
        else {
            _gameStateManager.LoadLoseGameScreen();
        }
    }
}
