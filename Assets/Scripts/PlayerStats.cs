using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int player1Lives;
    public static int player2Lives;
    public int startLives;
    private static int Player1Money;
    public static int player1Money 
    {
        get
        {
            return Player1Money;
        }
        set 
        {
            Player1Money = value;
            //Debug.Log("player 1 money: " + Player1Money);
        } 
    }
    private static int Player2Money;
    public static int player2Money
    {
        get
        {
            return Player2Money;
        }
        set
        {
            Player2Money = value;
            //Debug.Log("player 2 money: " + Player2Money);
        }
    }

    void Start()
    {
        player1Lives = startLives;
        player2Lives = startLives;
    }
}
