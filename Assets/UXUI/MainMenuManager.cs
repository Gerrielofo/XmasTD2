using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject inGameMenu;

    public GameObject backgroundBlur;

    public GameObject menuButtons;
    public GameObject settings;
    public GameObject exit;
    public GameObject gameInfo;
    public GameObject modeSelect;
    public GameObject connectScreen;
    public GameObject tutorialScreen;

    public string gameName;
    public string tutorialName;
    private bool wantSettings = false;
    private bool wantExit = false;
    private bool wantGameinfo = false;
    private bool wantPlay = false;
    private bool wantConnect = false;
    private bool wantTuturial = false;
    public bool toggleInGameMenu;


    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inGameMenu.SetActive(!toggleInGameMenu);
            toggleInGameMenu = !toggleInGameMenu;

            if (!toggleInGameMenu)
            {
                Time.timeScale = 1;
            }
            else if (toggleInGameMenu)
            {
                Time.timeScale = 0;
            }
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            inGameMenu.SetActive(!toggleInGameMenu);
            toggleInGameMenu = !toggleInGameMenu;
        }
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(gameName);
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene(tutorialName);
    }

    public void TogglePlay()
    {
        modeSelect.SetActive(!wantPlay);
        menuButtons.SetActive(wantPlay);
        backgroundBlur.SetActive(!wantPlay);
        wantPlay = !wantPlay;
    }

    public void ToggleTuturial()
    {
        tutorialScreen.SetActive(!wantTuturial);
        modeSelect.SetActive(wantTuturial);
        wantTuturial = !wantTuturial;
    }

    public void ToggleConnect()
    {
        connectScreen.SetActive(!wantConnect);
        modeSelect.SetActive(wantConnect);
        wantConnect = !wantConnect;
    }

    public void ToggleSettings()
    {
        settings.SetActive(!wantSettings);
        menuButtons.SetActive(wantSettings);
        backgroundBlur.SetActive(!wantSettings);
        wantSettings = !wantSettings;
    }

    public void ToggleExit()
    {
        exit.SetActive(!wantExit);
        menuButtons.SetActive(wantExit);
        backgroundBlur.SetActive(!wantExit);
        wantExit = !wantExit;
    }

    public void ToggleGameinfo()
    {
        gameInfo.SetActive(!wantGameinfo);
        settings.SetActive(wantGameinfo);
        wantGameinfo = !wantGameinfo;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    List<int> widths = new List<int>() { 1920, 1280, 960, 568 };
    List<int> heights = new List<int>() { 1080, 800, 540, 320 };

    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetFullscreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }
}
