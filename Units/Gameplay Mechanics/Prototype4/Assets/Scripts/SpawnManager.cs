using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Variables")]
    private float spawnRange = 9;
    [Header("References")]
    public GameObject enemyPrefab;

    void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    private Vector3 GenerateSpawnPoint(){
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnX, 0 , spawnZ);
        return randomPos;
    }
}
