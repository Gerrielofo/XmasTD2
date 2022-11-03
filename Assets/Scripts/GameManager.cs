using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerType { SinglePlayer, Multiplayer }

public class GameManager : MonoBehaviour
{
    
    public PlayerType playerType;
    public PlayerInputManager inputManager;
    public EconomyManager economyManager;
    public WaveManager waveManager;
    public PlayerWaveManager playerWaveManager;
    public EndGame endGame;
    public bool gameEnded = false;
    public bool UIassinged;


    private void Awake()
    {
        gameEnded = false;
    }

    public void Update()
    {
        if (inputManager.playerCount == 2 && UIassinged == false)
        {
            UIassinged = true;
            economyManager.GetComponent<EconomyManager>().PlayerStart();
            Debug.Log("asssinged UI");
            //endGame = GameObject.Find("PlayerCanvas").GetComponent<EndGame>();
        }
        if (gameEnded)
            return;
        if(PlayerStats.player1Lives <= 0)
        {
            GameEnd();
        }
        if(PlayerStats.player2Lives <= 0)
        {
            GameEnd();
        }
    }

    void GameEnd()
    {
        gameEnded = true;
        Time.timeScale = 0;
    }
}