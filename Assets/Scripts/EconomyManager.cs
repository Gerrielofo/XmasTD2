using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    [Header("References")]
    public WaveManager waveManager;
    [Header("Starting Ammounts")]
    public float startingMoney;
    public float startingEco;
    [Header("Player 1 Economy")]
    public float moneyP1;
    public float ecoP1;
    public TextMeshProUGUI P1MoneyDisplay;
    public TextMeshProUGUI P1EcoDisplay;
    [Header("Player 2 Economy")]
    public float moneyP2;
    public float ecoP2;
    public TextMeshProUGUI P2MoneyDisplay;
    public TextMeshProUGUI P2EcoDisplay;
    [Header("Countdown variables")]
    public float economyCountdown;
    public float timeBetweenEco;
    
    
    private void Start()
    {
        moneyP1 = startingMoney;
        moneyP2 = startingMoney;
        ecoP1 = startingEco;
        ecoP2 = startingEco;

        economyCountdown = timeBetweenEco;
    }

    // Update is called once per frame
    void Update()
    {
        economyCountdown -= Time.deltaTime;
        if(economyCountdown <= 0)
        {
            economyCountdown = timeBetweenEco;
            moneyP1 += ecoP1;
            P1EcoDisplay.text = ecoP1.ToString();
            P1MoneyDisplay.text = moneyP1.ToString();
            moneyP2 += ecoP2;
            P2EcoDisplay.text = ecoP2.ToString();
            P2MoneyDisplay.text = moneyP2.ToString();

        }
    }
}
