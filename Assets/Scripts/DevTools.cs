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

    }

    public void HealthDown()
    {

    }

    public void RoundSkip()
    {

    }

    public void MoneyUp()
    {

    }
}
