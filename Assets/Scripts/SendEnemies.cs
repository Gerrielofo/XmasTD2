using UnityEngine;

public class SendEnemies : MonoBehaviour
{
    public WaveManager waveManager;
    public EconomyManager economyManager;
    public PlayerStats playerStats;
    public int enemyID;
    public int ammount;
    public int cost;
    public int ecoBoost;
    private float sendingCDp1;
    private float sendingCDp2;
    private GameObject enemyPrefab;

    private void Awake()
    {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        economyManager = GameObject.Find("EconomyManager").GetComponent<EconomyManager>();
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
    }
    public void SendEnemy(int _enemyID, int _playerID, int _ammount, int _cost)
    {
        _enemyID = gameObject.GetComponent<SendEnemies>().enemyID;

        if(_playerID == 1)
        {
            if (_cost <= PlayerStats.player1Money && sendingCDp1 <= 0)
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
                economyManager.ecoP1 += ecoBoost;
                sendingCDp1 = 1;
            }
            else
            {
                Debug.Log("not met requirements to buy this for player: " + _playerID);
                enemyPrefab = waveManager.errorEnemy.prefab;
                
            }
        }
        else if(_playerID == 2)
        {
            if (_cost <= PlayerStats.player2Money && sendingCDp2 <= 0)
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
                economyManager.ecoP2 += ecoBoost;
                sendingCDp2 = 1;
            }
            else
            {
                Debug.Log("not mer requirements to buy this for player: " + _playerID);
                enemyPrefab = waveManager.errorEnemy.prefab;
            }
        }
        int ammount = _ammount;
        //Debug.Log("Ammount of enemies being send: " + _ammount);
        waveManager.cause = WaveManager.SendState.PLAYER;
        waveManager.GetComponent<WaveManager>().SpawnEnemy(enemyPrefab, ammount);
        
    }

    private void Update()
    {
        if(sendingCDp1 > 0)
        {
            sendingCDp1 -= Time.deltaTime;
        }
        if(sendingCDp2 > 0)
        {
            sendingCDp2 -= Time.deltaTime;
        }
    }
}
