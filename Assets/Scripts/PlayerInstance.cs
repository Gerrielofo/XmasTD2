using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInstance : MonoBehaviour
{
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInputManager inputManager = GameObject.Find("PlayerManager").GetComponent<PlayerInputManager>();
        EconomyManager economyManager = GameObject.Find("EconomyManager").GetComponent<EconomyManager>();
        WaveManager waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        int playerCount = inputManager.playerCount;
        Debug.Log(playerCount);

        LayerMask previousMask = camera.cullingMask;
        LayerMask playerMask;

        if (playerCount == 1)
        {
            gameObject.layer = 10;
            economyManager.P1EcoDisplay = gameObject.transform.GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            economyManager.P1MoneyDisplay = gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            playerMask = LayerMask.GetMask("Player1");
            
            camera.rect = new Rect(0, 0, 0.5f, 1f);
            
        }
        else
        {
            gameObject.layer = 11;
            economyManager.P2EcoDisplay = gameObject.transform.GetChild(1).GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            economyManager.P2MoneyDisplay = gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            playerMask = LayerMask.GetMask("Player2");

            camera.rect = new Rect(0.5f, 0, 0.5f, 1f);
        }

        LayerMask newMask = playerMask | previousMask;
        camera.cullingMask = newMask;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
