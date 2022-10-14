using UnityEngine;

public class SendEnemies : MonoBehaviour
{
    public WaveManager waveManager;
    public int enemyID;
    public int ammount;
    [SerializeField]private GameObject enemyPrefab;

    private void Awake()
    {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
    }

    public void SendEnemy(int _enemyID, int _playerID, int ammount)
    {
        //Debug.Log("spawning for player " + _playerID);
        //Debug.Log("spawning enemy with ID " + _enemyID);
        if(_playerID == 1)
        {
            switch (_enemyID)
            {
                default:
                    enemyPrefab = waveManager.halloween[0].prefab;
                    break;
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
                default:
                    enemyPrefab = waveManager.christmas[0].prefab;
                    break;
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
        if (enemyPrefab != null)
        {
            //Debug.Log("Script prefab = " + enemyPrefab);
            waveManager.cause = WaveManager.SendState.PLAYER;
            waveManager.GetComponent<WaveManager>().SpawnEnemy(enemyPrefab, ammount);
        }
    }
}
