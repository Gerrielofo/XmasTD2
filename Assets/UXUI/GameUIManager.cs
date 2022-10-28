using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameUIManager : MonoBehaviour
{
    public GameObject inGameUI;
    private bool wantIngameUI;
    private float options;
    bool optionsShown;
    private float delay;
    bool delayOn;


    void Start()
    {
        inGameUI = GameObject.Find("OverlayCanvas").transform.GetChild(0).gameObject;
    }

    void Update()
    {
        delay -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape) || options > 0.5f)
        {
            if (delay <= 0)
            {
                optionsShown = !optionsShown;
                if (optionsShown && !delayOn)
                {
                    delay = 2f;
                }
                delayOn = !delayOn;
                ToggleInGameUI();
            }
            
        }

        //if (optionsShown)
        //{
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}
    }
    public void ToggleInGameUI()
    {
        inGameUI.SetActive(!wantIngameUI);
        wantIngameUI = !wantIngameUI;
    }

    public void onOptions(InputAction.CallbackContext ctx) => options = ctx.ReadValue<float>();
}
