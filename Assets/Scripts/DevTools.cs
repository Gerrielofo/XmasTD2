using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    public WaveManager waveManager;
    public GameManager gameManager;
    public EconomyManager economyManager;
    public PlayerStats playerStats;

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
        economyManager = gameManager.economyManager;
        waveManager = gameManager.waveManager;
    }
    public void HealthUp()
    {
        PlayerStats.Player1Lives += 10;
        PlayerStats.Player2Lives += 10;
    }

    public void HealthDown()
    {
        PlayerStats.Player1Lives -= 10;
        PlayerStats.Player2Lives -= 10;
    }

    public void RoundSkip()
    {
        waveManager.StopSpawnWave();
        
        waveManager.nextWaveCountdown = waveManager.timeBetweenWaves;
        waveManager.nextWave++;
    }

    public void MoneyUp()
    {
        PlayerStats.player1Money += 1000;
        PlayerStats.player2Money += 1000;

        economyManager.P1MoneyDisplay.text = "Money: " + PlayerStats.player1Money;
        economyManager.P2MoneyDisplay.text = "Money: " + PlayerStats.player2Money;
    }
}
