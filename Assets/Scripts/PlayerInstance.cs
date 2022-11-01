using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInstance : MonoBehaviour
{


    public PlayerType playerType;
    public Camera camera;
    public GameObject christmasShop;
    public GameObject halloweenShop;
    public GameObject singlePlayerprefab;
    public GameObject multiPlayerPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerInputManager inputManager = GameObject.Find("PlayerManager").GetComponent<PlayerInputManager>();
        EconomyManager economyManager = GameObject.Find("EconomyManager").GetComponent<EconomyManager>();
        WaveManager waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        UIManager uIManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        int playerCount = inputManager.playerCount;
        Debug.Log(playerCount);


        LayerMask previousMask = camera.cullingMask;
        LayerMask playerMask = LayerMask.GetMask("Default");

        if (playerCount == 1)
        {
            gameObject.layer = 10;
            var children = gameObject.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                //Debug.Log(child.name);
                child.gameObject.layer = 10;
                if(child.GetComponent<SendEnemies>())
                {
                    child.GetComponent<SendEnemies>().playerID = 1;
                }
            }

            economyManager.P1MoneyDisplay = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            economyManager.P1EcoDisplay = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();

            uIManager.livesTextP1 = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
            uIManager.roundTextP1 = gameObject.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();

            gameObject.transform.GetComponent<ShopWheelController>().shopWheel = gameObject.transform.GetChild(0).GetChild(4).GetChild(1);
            playerMask = LayerMask.GetMask("Player1");

            if(playerType == PlayerType.Multiplayer)
            {
                gameManager.playerType = PlayerType.Multiplayer;
                camera.rect = new Rect(0, 0, 0.5f, 1f);
            }
            else
            {
                gameManager.playerType = PlayerType.SinglePlayer;
                camera.rect = new Rect(0, 0, 1f, 1f);
            }

            this.transform.parent.gameObject.name = "player1";
        }
        else if(playerCount == 2)
        {
            gameObject.layer = 11;
            var children = gameObject.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                //Debug.Log(child.name);
                child.gameObject.layer = 11;
                if (child.GetComponent<SendEnemies>())
                {
                    child.GetComponent<SendEnemies>().playerID = 2;
                }
            }

            economyManager.P2MoneyDisplay = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            economyManager.P2EcoDisplay = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();

            uIManager.livesTextP2 = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
            uIManager.roundTextP2 = gameObject.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();

            gameObject.transform.GetComponent<ShopWheelController>().shopWheel = gameObject.transform.GetChild(0).GetChild(4).GetChild(0);
            playerMask = LayerMask.GetMask("Player2");

            camera.rect = new Rect(0.5f, 0, 0.5f, 1f);

            this.transform.parent.gameObject.name = "player2";
        }

        LayerMask newMask = playerMask | previousMask;
        camera.cullingMask = newMask;

    }
}
