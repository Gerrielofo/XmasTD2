using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int player1Lives;
    public static int player2Lives;
    public int startLives;
    // Start is called before the first frame update
    void Start()
    {
        player1Lives = startLives;
        player2Lives = startLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
