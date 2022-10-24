using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public enum PlayerType { SinglePlayer, Multiplayer }
    public PlayerType playerType;
    public PlayerInputManager inputManager;
    private bool gameEnded = false;

    public GameObject gameOverUI;
    public GameObject victoryUI;
    public GameObject suddenDeathUI;

    public void Update()
    {
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