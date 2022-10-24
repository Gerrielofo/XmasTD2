using UnityEngine;

public class SendEnemies : MonoBehaviour
{
    public WaveManager waveManager;
    public EconomyManager economyManager;
    public PlayerStats playerStats;
    public int enemyID;
    public int ammount;
    public int cost;
    public GameObject enemyPrefab;

    private void Awake()
    {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        economyManager = GameObject.Find("EconomyManager").GetComponent<EconomyManager>();
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
    }
    public void SendEnemy(int _enemyID, int _playerID, int ammount, int _cost)
    {
        _enemyID = gameObject.GetComponent<SendEnemies>().enemyID;

        if(_playerID == 1)
        {
            if (_cost < PlayerStats.player1Money)
            {
                switch (_enemyID)
                {
                    case 0:
                        enemyPrefab = waveManager.halloween[_enemyID].prefab;
                        break;
                    case 1:
                        enemyPrefab = waveManager.halloween[_enemyID].prefab;
                        break;
                    case 2:
                        enemyPrefab = waveManager.halloween[_enemyID].prefab;
                        break;
                    case 3:
                        enemyPrefab = waveManager.halloween[_enemyID].prefab;
                        break;
                }
                PlayerStats.player1Money -= _cost;
            }
        }
        else if(_playerID == 2)
        {
            if (_cost < PlayerStats.player2Money)
            {
                switch (_enemyID)
                {
                    case 0:
                        enemyPrefab = waveManager.christmas[_enemyID].prefab;
                        break;
                    case 1:
                        enemyPrefab = waveManager.christmas[_enemyID].prefab;
                        break;
                    case 2:
                        enemyPrefab = waveManager.christmas[_enemyID].prefab;
                        break;
                    case 3:
                        enemyPrefab = waveManager.christmas[_enemyID].prefab;
                        break;
                }
                PlayerStats.player2Money -= _cost;
            }
        }
     
        waveManager.cause = WaveManager.SendState.PLAYER;
        waveManager.GetComponent<WaveManager>().SpawnEnemy(enemyPrefab, ammount);
    }
}
