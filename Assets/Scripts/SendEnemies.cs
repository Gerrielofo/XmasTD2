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
            
        }
        waveManager.cause = WaveManager.SendState.PLAYER;
        waveManager.GetComponent<WaveManager>().SpawnEnemy(_enemyPrefab, ammount);
    }
}
