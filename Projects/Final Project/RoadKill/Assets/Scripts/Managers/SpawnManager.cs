using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance { get; private set; }
    public GameObject enemyPrefab;
    public Transform[] spawnPonints; 
    private WaveManager waveManager;

    public float spawnRate = 2f;
    public float spawnDelay = 1f;
    public int minX = -10;
    public int maxX = 10;


    void Awake(){

        waveManager = GetComponent<WaveManager>();
    }
    

    //This gets the currentWave from game manager and times it by 2 to get the number of enemies to spawn
    public void Spawn(int enemySpawned)
        {
            for (int i = enemySpawned; i > 0; i--){
                StartCoroutine(spawnInSeconds());
            }
            
        }
    

    //spawn delay for spawning enemies
    IEnumerator spawnInSeconds()
    {
        int index = Random.Range(0, spawnPonints.Length);
        Instantiate(enemyPrefab, spawnPonints[index].position, spawnPonints[index].rotation);
        Debug.Log("Count of spawn");
        yield return new WaitForSeconds(spawnDelay);
    }
}
