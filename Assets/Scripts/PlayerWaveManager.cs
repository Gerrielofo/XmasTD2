using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveManager;

public class PlayerWaveManager : MonoBehaviour
{
    public Transform[] playerSpawns;
    public float sendingCdP1;
    public float sendingCdP2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sendingCdP1 > 0)
        {
            sendingCdP1 -= Time.deltaTime;
        }
        if (sendingCdP2 > 0)
        {
            sendingCdP2 -= Time.deltaTime;
        }
    }

    public void PlayerSend(GameObject _enemyPrefab, int _amount, int p, int test)
    {
        //Debug.Log("PlayerSend: " + _enemyPrefab + " PlayerID: " + _playerID);
        //Debug.Log("Test: " + test);

        int s = p - 1;


        for (int a = 0; a < _amount; a++)
        {
           // Debug.Log("Tim's Bullshit: " + s);
            GameObject Obj = Instantiate(_enemyPrefab, playerSpawns[s].position, Quaternion.identity);
            Obj.GetComponent<EnemyModelManager>().SetModel(s);
        }
    }
}
