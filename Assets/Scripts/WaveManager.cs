using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("References")]
    public EconomyManager economyManager;
    public enum SpawnState { SPAWNING, WAITING, COUNTING, FINISHED };
    public enum SendState { NATURAL, PLAYER};
    [Header("Enemy Arrays")]
    public SendState cause;
    public Enemy[] halloween;
    public Enemy[] christmas;
    [Header("Spawn Locations")]
    public Transform[] naturalSpawns;
    public Transform[] playerSpawns;
    [Header("Wave Info")]
    public SpawnState state = SpawnState.COUNTING;
    public static int currentWave = 0;
    public float timeBetweenWaves = 5f;
    public float nextWaveCountdown;
    public Wave[] waves;
    private int nextWave = 0;



    void Start()
    {
        nextWaveCountdown = timeBetweenWaves;
    }

    public void SendEnemy(int kaas, int peper)
    {

    }
    private void Update()
    {

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted(waves[currentWave]);
            }
            else
            {
                return;
            }
        }
        if (nextWaveCountdown <= 0 && state != SpawnState.FINISHED)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            if (state == SpawnState.COUNTING)
            {
                nextWaveCountdown -= Time.deltaTime;
            }
        }
    }

    void WaveCompleted(Wave _wave)
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        
        if (nextWave + 1 == waves.Length)
        {
            Debug.Log("No more Waves to Spawn");
            state = SpawnState.FINISHED;
        }
        else
        {
            economyManager.ecoP1 += _wave.waveReward;
            economyManager.ecoP2 += _wave.waveReward;
            Debug.Log("eco p1: " + economyManager.ecoP1);
            Debug.Log("eco p2: " + economyManager.ecoP2);
            nextWaveCountdown = timeBetweenWaves;
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        timeBetweenWaves -= Time.deltaTime;

        if (timeBetweenWaves <= 0)
        {
            timeBetweenWaves = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        currentWave = _wave.waveNumber;
        Debug.Log("Spawning Wave : " + currentWave);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.enemies.Length; i++)
        {
            int ammountSpawned = 0;
            Debug.Log("Enemy number: " + (i + 1));
            for( ammountSpawned = 0; ammountSpawned < _wave.enemies[i].ammount; ammountSpawned++)
            {
                Debug.Log("ammount of enemies spawned: " + (ammountSpawned + 1));
                cause = SendState.NATURAL;
                SpawnEnemy(_wave.enemies[i].enemyPrefab, 1);
                yield return new WaitForSeconds(1f / _wave.enemies[i].spawnRate);
            }
            
        }

        state = SpawnState.WAITING;
        yield break;
    }

    public void SpawnEnemy(GameObject enemyPrefab, int _ammount)
    {

        if(cause == SendState.NATURAL)
        {
            for (int s = 0; s < naturalSpawns.Length; s++)
            {
                Instantiate(enemyPrefab, naturalSpawns[s].position, Quaternion.identity);
            }   
        }
        if (cause == SendState.PLAYER)
        {
            for (int a = 0; a < _ammount; a++)
            {
                for (int s = 0; s <= naturalSpawns.Length; s++)
                {
                    Instantiate(enemyPrefab, playerSpawns[s].position, Quaternion.identity);
                }
            }
        }
    }
}