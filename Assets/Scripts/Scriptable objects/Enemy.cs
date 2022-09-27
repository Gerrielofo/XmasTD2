using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    [Header("Enemy Info")]
    public string name;
    public GameObject enemyPrefab;
    public int ammount;
    public float spawnRate;
    public int damage = 1;

    public void EndPath()
    {
        PlayerStats.player1Lives -= damage;
    }
}
