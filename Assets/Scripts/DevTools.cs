using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    public WaveManager waveManager;
    public GameManager gameManager;
    public EconomyManager economyManager;
    public PlayerStats playerStats;

    private bool DevToolCooldown;
    private float DTC_Timer;

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
        economyManager = gameManager.economyManager;
        waveManager = gameManager.waveManager;
    }
    public void HealthUp()
    {
        if (!DevToolCooldown)
        {
            PlayerStats.Player1Lives += 10;
            PlayerStats.Player2Lives += 10;

            DevToolCooldown = true;
            DTC_Timer = 1;
        }
    }

    public void HealthDown()
    {
        if (!DevToolCooldown)
        {
            PlayerStats.Player1Lives -= 10;
            PlayerStats.Player2Lives -= 10;

            DevToolCooldown = true;
            DTC_Timer = 1;
        }
    }

    public void RoundSkip()
    {
        if (!DevToolCooldown)
        {
            waveManager.StopSpawnWave();

            waveManager.nextWaveCountdown = waveManager.timeBetweenWaves;
            waveManager.nextWave++;

            DevToolCooldown = true;
            DTC_Timer = 1;
        }
       
    }

    public void MoneyUp()
    {
        if (!DevToolCooldown)
        {
            PlayerStats.player1Money += 1000;
            PlayerStats.player2Money += 1000;

            economyManager.P1MoneyDisplay.text = "Money: " + PlayerStats.player1Money;
            economyManager.P2MoneyDisplay.text = "Money: " + PlayerStats.player2Money;

            DevToolCooldown = true;
            DTC_Timer = 1;
        }
    }


    public void Update()
    {
        if(DTC_Timer > 0)
        {
            DTC_Timer -= Time.deltaTime;
        }
    }
}
