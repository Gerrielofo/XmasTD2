using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEnemies : MonoBehaviour
{
    public WaveManager waveManager;
    int ammount;
    public int enemyID;
    GameObject _enemyPrefab;

    private void Awake()
    {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
    }
    public void SendEnemy(int _enemyID, int _playerID)
    {
        _enemyID = gameObject.GetComponent<SendEnemies>().enemyID;

        switch (_enemyID)
        {
            default:
                if (_playerID == 1)
                {
                    _enemyPrefab = waveManager.halloween[_enemyID].enemyPrefab;
                    ammount = waveManager.halloween[_enemyID].ammount;
                }
                else
                {
                    _enemyPrefab = waveManager.christmas[_enemyID].enemyPrefab;
                    ammount = waveManager.christmas[_enemyID].ammount;
                }
                break;

            case 0:
                if (_playerID == 1)
                {
                    _enemyPrefab = waveManager.halloween[_enemyID].enemyPrefab;
                    ammount = waveManager.halloween[_enemyID].ammount;
                }
                else
                {
                    _enemyPrefab = waveManager.christmas[_enemyID].enemyPrefab;
                    ammount = waveManager.christmas[_enemyID].ammount;
                }
                break;

            case 1:
                if (_playerID == 1)
                {
                    _enemyPrefab = waveManager.halloween[_enemyID].enemyPrefab;
                    ammount = waveManager.halloween[_enemyID].ammount;
                }
                else
                {
                    _enemyPrefab = waveManager.christmas[_enemyID].enemyPrefab;
                    ammount = waveManager.christmas[_enemyID].ammount;
                }
                break;

            case 2:
                if (_playerID == 1)
                {
                    _enemyPrefab = waveManager.halloween[_enemyID].enemyPrefab;
                    ammount = waveManager.halloween[_enemyID].ammount;
                }
                else
                {
                    _enemyPrefab = waveManager.christmas[_enemyID].enemyPrefab;
                    ammount = waveManager.christmas[_enemyID].ammount;
                }
                break;

            case 3:
                if (_playerID == 1)
                {
                    _enemyPrefab = waveManager.halloween[_enemyID].enemyPrefab;
                    ammount = waveManager.halloween[_enemyID].ammount;
                }
                else
                {
                    _enemyPrefab = waveManager.christmas[_enemyID].enemyPrefab;
                    ammount = waveManager.christmas[_enemyID].ammount;
                }
                break;
        }
        waveManager.cause = WaveManager.SendState.PLAYER;
        waveManager.GetComponent<WaveManager>().SpawnEnemy(_enemyPrefab, ammount);
    }
}
