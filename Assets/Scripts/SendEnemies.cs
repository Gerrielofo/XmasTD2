using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEnemies : MonoBehaviour
{
    public WaveManager waveManager;

    int playerID = 1;
    int ammount;
    GameObject _enemyPrefab;

    private void Awake()
    {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
    }
    public void SendEnemy(int EnemyID)
    {
        switch (EnemyID)
        {
            default:
                if (playerID == 1)
                {
                    _enemyPrefab = waveManager.halloween[EnemyID].enemyPrefab;
                    ammount = waveManager.halloween[EnemyID].ammount;
                }
                else
                {
                    _enemyPrefab = waveManager.christmas[EnemyID].enemyPrefab;
                    ammount = waveManager.christmas[EnemyID].ammount;
                }
                break;

            case 0:
                if (playerID == 1)
                {
                    _enemyPrefab = waveManager.halloween[EnemyID].enemyPrefab;
                    ammount = waveManager.halloween[EnemyID].ammount;
                }
                else
                {
                    _enemyPrefab = waveManager.christmas[EnemyID].enemyPrefab;
                    ammount = waveManager.christmas[EnemyID].ammount;
                }
                break;

            case 1:
                if (playerID == 1)
                {
                    _enemyPrefab = waveManager.halloween[EnemyID].enemyPrefab;
                    ammount = waveManager.halloween[EnemyID].ammount;
                }
                else
                {
                    _enemyPrefab = waveManager.christmas[EnemyID].enemyPrefab;
                    ammount = waveManager.christmas[EnemyID].ammount;
                }
                break;

            case 2:
                if (playerID == 1)
                {
                    _enemyPrefab = waveManager.halloween[EnemyID].enemyPrefab;
                    ammount = waveManager.halloween[EnemyID].ammount;
                }
                else
                {
                    _enemyPrefab = waveManager.christmas[EnemyID].enemyPrefab;
                    ammount = waveManager.christmas[EnemyID].ammount;
                }
                break;

            case 3:
                if (playerID == 1)
                {
                    _enemyPrefab = waveManager.halloween[EnemyID].enemyPrefab;
                    ammount = waveManager.halloween[EnemyID].ammount;
                }
                else
                {
                    _enemyPrefab = waveManager.christmas[EnemyID].enemyPrefab;
                    ammount = waveManager.christmas[EnemyID].ammount;
                }
                break;
        }
        waveManager.cause = WaveManager.SendState.PLAYER;
        waveManager.GetComponent<WaveManager>().SpawnEnemy(_enemyPrefab, ammount);
    }
}
