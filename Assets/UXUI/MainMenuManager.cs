using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject menuButtons;
    public GameObject settings;
    public GameObject exit;
    public GameObject gameInfo;
    
    private bool wantSettings = false;
    private bool wantExit = false;
    private bool wantGameinfo = false;
    public void StartGame()
    {
        SceneManager.LoadScene("Test Xander");
    }
    public void ToggleSettings()
    {
        settings.SetActive(!wantSettings);
        menuButtons.SetActive(wantSettings);
        wantSettings = !wantSettings;
    }

    public void ToggleExit()
    {
        exit.SetActive(!wantExit);
        menuButtons.SetActive(wantExit);
        wantExit = !wantExit;
    }

    public void ToggleGameinfo()
    {
        gameInfo.SetActive(!wantGameinfo);
        settings.SetActive(wantGameinfo);
        wantGameinfo = !wantGameinfo;
    }

    public void SetFullscreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }
}
