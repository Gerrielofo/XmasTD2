using System.Collections;
using UnityEngine;

public class SendEnemies : MonoBehaviour
{
    public GameManager gameManager;
    public WaveManager waveManager;
    public EconomyManager economyManager;
    public PlayerStats playerStats;
    public PlayerWaveManager playerWaveManager;
    public int playerID;
    public int enemyID;
    public int ammount;
    public int cost;
    public int ecoBoost;

    private GameObject enemyPrefab;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        waveManager = gameManager.waveManager;
        economyManager = gameManager.economyManager;
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
        playerWaveManager = waveManager.GetComponent<PlayerWaveManager>();
    }
    public void SendEnemy(int _enemyID, int _playerID, int _ammount, int _cost)
    {
        Debug.Log("send enemies - " + _enemyID);
        if (_playerID == 1)
        {
            if (_cost <= PlayerStats.player1Money && playerWaveManager.sendingCdP1 <= 0)
            {

                enemyPrefab = waveManager.halloween[_enemyID].prefab;

                PlayerStats.player1Money -= _cost;
                economyManager.ecoP1 += ecoBoost;
                economyManager.P1EcoDisplay.text = "Eco: " + economyManager.ecoP1;
                playerWaveManager.sendingCdP1 = 1;
                StartCoroutine(Spawn(_ammount, enemyPrefab, _playerID));

            }
            else
            {
                //Debug.Log("not met requirements to buy this for player: " + _playerID);
                enemyPrefab = waveManager.errorEnemy.prefab;

            }
            playerWaveManager.sendingCdP1++;
        }
        else if (_playerID == 2)
        {
            if (_cost <= PlayerStats.player2Money && playerWaveManager.sendingCdP2 <= 0)
            {
                enemyPrefab = waveManager.christmas[_enemyID].prefab;
                StartCoroutine(Spawn(_ammount, enemyPrefab, _playerID));
                PlayerStats.player2Money -= _cost;
                economyManager.ecoP2 += ecoBoost;
                economyManager.P2EcoDisplay.text = "Eco: " + economyManager.ecoP2;
            }
            else
            {
                //Debug.Log("not met requirements to buy this for player: " + _playerID);
                enemyPrefab = waveManager.errorEnemy.prefab;
            }
            playerWaveManager.sendingCdP2++;
        }
    }


    IEnumerator Spawn(int _amount, GameObject _enemyPrefab, int p) { 
        int test = p;

        Debug.Log("SpawnFunction: " + _enemyPrefab + " PlayerID: " + p);
        for (int a = 0; a < _amount; a++)
        {
            waveManager.GetComponent<PlayerWaveManager>().PlayerSend(_enemyPrefab, _amount, p, test);
            yield return new WaitForSeconds(0.5f);
        }
        StopCoroutine(Spawn(_amount, _enemyPrefab, p));
        yield break;
    }
}
