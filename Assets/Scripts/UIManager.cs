using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI roundText;

    void Update()
    {
        livesText.text = "Lives: " + PlayerStats.player1Lives;
        //Debug.Log(PlayerStats.player1Lives + " lives left");
        roundText.text = "Round " + WaveManager.currentWave;
    }
}
