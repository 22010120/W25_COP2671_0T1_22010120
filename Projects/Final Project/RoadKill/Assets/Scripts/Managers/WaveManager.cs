using UnityEngine;


public class WaveManager : MonoBehaviour
{


    public int enemySpawned = 1;
    public int enemyRemaining;
    private int currentWave = 1;
    private SpawnManager spawnManager;
    private PlayerStats playerStats;

    void Awake()
    {
        Debug.Log("WaveManager Awake");
        spawnManager = GetComponent<SpawnManager>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public void publicStart(){
        StartWave();
    }

    void StartWave()
    {
        playerStats.health = 100;
        enemySpawned += currentWave;
        enemyRemaining = enemySpawned;
        spawnManager.Spawn(enemySpawned);
    }

    void EndWave()
    {
        Debug.Log("Wave ended");
        BuyPhase();
    }

    public void EnemyKill()
    {
        enemyRemaining -= 1;
        if (enemyRemaining == 0) {
            EndWave();
        }
    }

    void BuyPhase()
    {
        Debug.Log("No buy yet, Next wave");
        currentWave += 1;
        StartWave();
    }


}