using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    [Header("References")]
    public WaveManager waveManager;
    public PlayerInputManager inputManager;
    public GameManager gameManager;
    public PlayerType playerType;
    [Header("Starting Ammounts")]
    public int startingMoney;
    public int startingEco;
    [Header("Player 1 Economy")]
    public int ecoP1;
    public TextMeshProUGUI P1MoneyDisplay;
    public TextMeshProUGUI P1EcoDisplay;
    [Header("Player 2 Economy")]
    public int ecoP2;
    public TextMeshProUGUI P2MoneyDisplay;
    public TextMeshProUGUI P2EcoDisplay;
    [Header("Countdown variables")]
    public float economyCountdown;
    public float timeBetweenEco;
    
    
    public void PlayerStart()
    {
        inputManager = GameObject.Find("PlayerManager").GetComponent<PlayerInputManager>();
        if(playerType == PlayerType.Multiplayer)
        {
            if (inputManager.playerCount == 2)
            {
                PlayerStats.player1Money += startingMoney;
                PlayerStats.player2Money += startingMoney;

                ecoP1 = startingEco;
                ecoP2 = startingEco;

                P1EcoDisplay.text = "Eco: " + ecoP1;
                P1MoneyDisplay.text = "Money: " + PlayerStats.player1Money;

                P2EcoDisplay.text = "Eco: " + ecoP2;
                P2MoneyDisplay.text = "Money: " + PlayerStats.player2Money;

                economyCountdown = timeBetweenEco;
            }
        }
        else
        {
            if (inputManager.playerCount == 1)
            {
                PlayerStats.player1Money += startingMoney;
                PlayerStats.player2Money += startingMoney;
                ecoP1 = startingEco;
                ecoP2 = startingEco;

                P1EcoDisplay.text = "Eco: " + ecoP1;
                P1MoneyDisplay.text = "Money: " + PlayerStats.player1Money;

                P2EcoDisplay.text = "Eco: " + ecoP2;
                P2MoneyDisplay.text = "Money: " + PlayerStats.player2Money;

                economyCountdown = timeBetweenEco;
            }
        }
        
    }


    void Update()
    {
        if(inputManager.playerCount == 2)
        {
            P1MoneyDisplay.text = "Money: " + PlayerStats.player1Money;
            P2MoneyDisplay.text = "Money: " + PlayerStats.player2Money;
            economyCountdown -= Time.deltaTime;
            if (economyCountdown <= 0)
            {// Player 1 money
                PlayerStats.player1Money += ecoP1;
                P1EcoDisplay.text = "Eco: " + ecoP1;
                // Player 2 money
                PlayerStats.player2Money += ecoP2;
                P2EcoDisplay.text = "Eco: " + ecoP2;

                economyCountdown = timeBetweenEco;
            }
        }
        
    }
}
