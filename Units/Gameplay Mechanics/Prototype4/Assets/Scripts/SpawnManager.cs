using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Variables")]
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    [Header("References")]
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPoint(), powerupPrefab.transform.rotation);
        
    }
    void Update(){
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPoint(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn){
        for (int i = 0; i < enemiesToSpawn; i++){
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
        }
    }
    // Update is called once per frame
    private Vector3 GenerateSpawnPoint(){
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnX, -1.4f , spawnZ);
        return randomPos;
    }
}
