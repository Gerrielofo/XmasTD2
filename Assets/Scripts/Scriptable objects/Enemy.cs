using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "EnemyData")]
public class Enemy
{
    public string name;
    public GameObject enemyPrefab;
    public int Health;
    public int ammount;
    public int spawnRate;
    public int speed;
}
