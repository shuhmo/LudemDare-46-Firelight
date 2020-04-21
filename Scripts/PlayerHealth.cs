using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Warmth warmth;
    private float playerHealth;
    private bool isDead;
    [SerializeField] private bool useDeath;
    [SerializeField] private float maxHp;
    [SerializeField] private FireScript playerTorchFireScript;
    [SerializeField] Text text;
    private PlayerMovement _playerMovement;


    // Start is called before the first frame update
    private void Awake()
    {
        warmth = GetComponent<Warmth>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    private void Start()
    {
        playerHealth = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (warmth.isFreezing())
        {
            if (playerHealth > 0)
            {
                playerHealth -= Time.deltaTime * 15;
                Debug.Log(playerHealth);
            }
            else
            {
                IsDead();
            }
        }
        else
        {
            if (playerHealth < maxHp)
            {
                playerHealth += Time.deltaTime * 20;
                Debug.Log("Warming");
                Debug.Log(playerHealth);
            }
        }
    }

    private void IsDead()
    {
        isDead = true;
        if (useDeath)
        {
            _playerMovement.setPlayerMovementLocked(true);
            text.text = "You Died";

        }
    }
    public float GetHealth()
    {
        return playerHealth;
    }
    public bool GetDead()
    {
        return isDead;
    }
      
}
