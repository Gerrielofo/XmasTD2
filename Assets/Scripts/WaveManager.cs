using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING, FINISHED };
    public int currentWave = 0;
    private SpawnState state = SpawnState.COUNTING;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public Wave[] waves;

    private int nextWave = 0;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0 && state != SpawnState.FINISHED)
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
                waveCountdown -= Time.deltaTime;
            }
        }
    }

    void WaveCompleted()
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
            waveCountdown = timeBetweenWaves;
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
                SpawnEnemy(_wave.enemies[i].enemyPrefab);
                yield return new WaitForSeconds(1f / _wave.enemies[i].spawnRate);
            }
            
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab);
    }
}