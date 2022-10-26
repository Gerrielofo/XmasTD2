using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressToJoin : MonoBehaviour
{
    private PlayerInputManager inputManager;
    public GameObject player1JoinScreen;
    public GameObject player2JoinScreen;
    //public GameObject player1JoinedScreen;
    //public GameObject player2JoinedScreen;

    public GameObject start;


    void Start()
    {
        inputManager = GameObject.Find("PlayerManager").GetComponent<PlayerInputManager>();
    }

    void Update()
    {
        if (inputManager.playerCount == 1)
        {
            player1JoinScreen.SetActive(false);
            //player1JoinedScreen.SetActive(true);
        }
        else if (inputManager.playerCount == 2)
        {
            player2JoinScreen.SetActive(false);
            //player2JoinedScreen.SetActive(true);
            start.SetActive(true);
        }
    }
}
