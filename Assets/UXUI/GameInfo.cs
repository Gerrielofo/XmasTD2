using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [Header("General")]
    public GameObject selectPanel;
    public GameObject gameInfo;
    public GameObject towerInfo;
    public GameObject controlsPanel;
    public GameObject creditsPanel;

    bool wantTowerinfo = false;
    bool wantGameinfo = false;
    bool wantControls = false;
    bool wantCredits = false;

    [Header("Tower info")]
    public GameObject selectTowerInfo;
    public GameObject tower1Info;
    public GameObject tower2Info;
    public GameObject tower3Info;
    public GameObject tower4Info;
    bool tower1 = false;
    bool tower2 = false;
    bool tower3 = false;
    bool tower4 = false;

    
    public void ToggleGameInfo()
    {
        gameInfo.SetActive(!wantGameinfo);
        selectPanel.SetActive(wantGameinfo);

        towerInfo.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);

        wantGameinfo = !wantGameinfo;
        wantTowerinfo = false;
        wantControls = false;
        wantCredits = false;
    }

    public void ToggleTowerInfo()
    {
        towerInfo.SetActive(!wantTowerinfo);
        selectPanel.SetActive(wantTowerinfo);

        gameInfo.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);

        wantTowerinfo = !wantTowerinfo;
        wantGameinfo = false;
        wantControls = false;
        wantCredits = false;
    }

    public void ToggleControls()
    {
        controlsPanel.SetActive(!wantControls);
        selectPanel.SetActive(wantControls);

        towerInfo.SetActive(false);
        gameInfo.SetActive(false);
        creditsPanel.SetActive(false);

        wantControls = !wantControls;
        wantTowerinfo = false;
        wantGameinfo = false;
        wantCredits = false;
    }

    public void ToggleCredits()
    {
        creditsPanel.SetActive(!wantCredits);
        selectPanel.SetActive(wantCredits);

        towerInfo.SetActive(false);
        gameInfo.SetActive(false);
        controlsPanel.SetActive(false);

        wantCredits = !wantCredits;
        wantTowerinfo = false;
        wantGameinfo = false;
        wantControls = false;
    }
    

    public void ToggleTower1()
    {
        selectTowerInfo.SetActive(tower1);

        tower1Info.SetActive(!tower1);
        tower2Info.SetActive(false);
        tower3Info.SetActive(false);
        tower4Info.SetActive(false);

        tower1 = !tower1;
        tower2 = false;
        tower3 = false;
        tower4 = false;
    }

    public void ToggleTower2()
    {
        selectTowerInfo.SetActive(tower2);

        tower1Info.SetActive(false); ;
        tower2Info.SetActive(!tower2);
        tower3Info.SetActive(false);
        tower4Info.SetActive(false);

        tower2 = !tower2;
        tower1 = false;
        tower3 = false;
        tower4 = false;
    }

    public void ToggleTower3()
    {
        selectTowerInfo.SetActive(tower3);

        tower1Info.SetActive(false);
        tower2Info.SetActive(false);
        tower3Info.SetActive(!tower3);
        tower4Info.SetActive(false);

        tower3 = !tower3;
        tower1 = false;
        tower2 = false;
        tower4 = false;
    }

    public void ToggleTower4()
    {
        selectTowerInfo.SetActive(tower4);

        tower1Info.SetActive(false);
        tower2Info.SetActive(false);
        tower3Info.SetActive(false);
        tower4Info.SetActive(!tower4);

        tower4 = !tower4;
        tower1 = false;
        tower2 = false;
        tower3 = false;
    }
}
