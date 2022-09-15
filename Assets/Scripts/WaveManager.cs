using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING, FINISHED };
    private int currentWave = 0;
    public Wave[] waves;

    private int nextWave = 0;
    private int numberOfLoops = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private SpawnState state = SpawnState.COUNTING;


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
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            numberOfLoops++;
            if (numberOfLoops < 4)
            {
                nextWave = 0;
                Debug.Log("All waves Completed");
            }
            else
            {
                state = SpawnState.FINISHED;
            }
        }
        else
        {
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
        Debug.Log("Spawning Wave: " + _wave.waveNumber);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.enemies.Length; i++)
        {
            SpawnEnemy(_wave.enemies[i].enemyPrefab);
            yield return new WaitForSeconds(1f / _wave.enemies[i].spawnRate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        //waveManager.GetComponent<SendEnemies>().SendSlime(_slimeID);
    }
}