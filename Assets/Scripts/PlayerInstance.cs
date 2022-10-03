using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInstance : MonoBehaviour
{
    public Camera camera;
    public GameObject christmasShop;
    public GameObject halloweenShop;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInputManager inputManager = GameObject.Find("PlayerManager").GetComponent<PlayerInputManager>();
        EconomyManager economyManager = GameObject.Find("EconomyManager").GetComponent<EconomyManager>();
        WaveManager waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        UIManager uIManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        int playerCount = inputManager.playerCount;
        Debug.Log(playerCount);


        LayerMask previousMask = camera.cullingMask;
        LayerMask playerMask = LayerMask.GetMask("Default");

        if (playerCount == 1)
        {
            gameObject.layer = 10;
            economyManager.P1MoneyDisplay = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            economyManager.P1EcoDisplay = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();

            uIManager.livesTextP1 = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
            uIManager.roundTextP1 = gameObject.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();

            gameObject.transform.GetComponent<ShopWheelController>().shopWheel = gameObject.transform.GetChild(0).GetChild(4).GetChild(0);
            playerMask = LayerMask.GetMask("Player1");

            camera.rect = new Rect(0, 0, 0.5f, 1f);

        }
        else if(playerCount == 2)
        {
            economyManager.P2MoneyDisplay = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            economyManager.P2EcoDisplay = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();

            uIManager.livesTextP2 = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
            uIManager.roundTextP2 = gameObject.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();

            gameObject.transform.GetComponent<ShopWheelController>().shopWheel = gameObject.transform.GetChild(0).GetChild(4).GetChild(1);
            playerMask = LayerMask.GetMask("Player2");

            camera.rect = new Rect(0.5f, 0, 0.5f, 1f);
        }

        LayerMask newMask = playerMask | previousMask;
        camera.cullingMask = newMask;

    }
}
