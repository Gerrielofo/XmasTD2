using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string name;
    public GameObject enemyPrefab;
    public int Health;
    public int ammount;
    public float spawnRate;
    public int speed;
}
