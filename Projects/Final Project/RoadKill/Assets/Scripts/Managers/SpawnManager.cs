using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance { get; private set; }
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; 
    private WaveManager waveManager;

    public float spawnRate = 2f;
    public float spawnDelay = 1f;
    public int minX = -10;
    public int maxX = 10;
    public int enemies = 0;


    void Awake(){

        waveManager = GetComponent<WaveManager>();
    }
    

    //This gets the currentWave from game manager and times it by 2 to get the number of enemies to spawn
    public void Spawn(int enemySpawned)
        {
                enemies = enemySpawned;
                StartCoroutine(spawnInSeconds());
       
           
        }
        
    //spawn delay for spawning enemies
    IEnumerator spawnInSeconds()
    {
        int index = Random.Range(0, spawnPoints.Length);
        for (int i = enemies; i > 0; i--){
            Instantiate(enemyPrefab, spawnPoints[index].position, spawnPoints[index].rotation);
        }
        Debug.Log("Count of spawn");
        yield return new WaitForSeconds(spawnDelay);
    }
}
