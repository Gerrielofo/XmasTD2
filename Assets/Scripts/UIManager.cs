using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI roundText;

    void Update()
    {
        livesText.text = "Lives: " + PlayerStats.Lives;
        roundText.text = "Round " + WaveManager.currentWave;

    }
}
