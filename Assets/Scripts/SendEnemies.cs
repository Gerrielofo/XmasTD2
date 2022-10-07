using UnityEngine;

public class SendEnemies : MonoBehaviour
{
    public WaveManager waveManager;
    public int enemyID;
    public int ammount;
    public GameObject enemyPrefab;

    private void Awake()
    {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
    }
    public void SendEnemy(int _enemyID, int _playerID, int ammount)
    {
        _enemyID = gameObject.GetComponent<SendEnemies>().enemyID;
        if(_playerID == 1)
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

        }
        else if(_playerID == 2)
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
        }
     
        waveManager.cause = WaveManager.SendState.PLAYER;
        waveManager.GetComponent<WaveManager>().SpawnEnemy(enemyPrefab, ammount);
    }
}
