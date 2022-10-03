using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressToJoin : MonoBehaviour
{
    private PlayerInputManager inputManager;
    public GameObject player1JoinScreen;
    public GameObject player2JoinScreen;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.Find("PlayerManager").GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.playerCount == 1)
        {
            player1JoinScreen.SetActive(false);
        }
        else if (inputManager.playerCount == 2)
        {
            player2JoinScreen.SetActive(false);
        }
    }
}
