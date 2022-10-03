using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI livesTextP1;
    public TextMeshProUGUI livesTextP2;
    public TextMeshProUGUI roundTextP1;
    public TextMeshProUGUI roundTextP2;
    public PlayerInputManager playerInputManager;

    void Update()
    {
        if(playerInputManager.playerCount == 2)
        {
            livesTextP1.text = "Lives: " + PlayerStats.player1Lives;
            livesTextP2.text = "Lives: " + PlayerStats.player2Lives;
            //Debug.Log(PlayerStats.player1Lives + " lives left");
            roundTextP1.text = "Round " + WaveManager.currentWave;
            roundTextP2.text = "Round " + WaveManager.currentWave;
        }
    }
}
