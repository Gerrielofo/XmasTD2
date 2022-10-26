using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boss
{
    [SerializeField]
    private string bossType;
    public GameObject bossPrefab;
    public int health;
    public int damage;
    public int speed;

    public void EndPath()
    {
        PlayerStats.player1Lives -= damage;
    }
}
