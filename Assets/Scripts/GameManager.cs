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
    private bool gameEnded = false;
    public bool UIassinged;

    public GameObject gameOverUI;
    public GameObject victoryUI;
    public GameObject suddenDeathUI;



    public void Update()
    {
        if (inputManager.playerCount == 2 && UIassinged == false)
        {
            UIassinged = true;
            economyManager.GetComponent<EconomyManager>().PlayerStart();
            Debug.Log("asssinged UI");
            
        }
        if (gameEnded)
            return;
        if(PlayerStats.player1Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}