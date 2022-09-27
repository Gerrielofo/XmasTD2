using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int player1Lives;
    public static int player2Lives;
    public int startLives;
    public static int player1Money;
    public static int player2Money;
    public int startMoney;

    public int money;

    void Start()
    {
        player1Lives = startLives;
        player2Lives = startLives;

        player1Money = startMoney;
        player2Money = startMoney;
    }

    private void Update()
    {
        money = player1Money;
    }
}
