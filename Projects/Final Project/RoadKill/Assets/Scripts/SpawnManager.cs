using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance { get; private set; }
    public GameObject enemyPrefab;
    public Transform[] spawnPonints;
    public GameObject GameManager; 

    public float spawnRate = 2f;
    public float spawnDelay = 1f;
    public int minX = -10;
    public int maxX = 10;
    public int currentEnemies = 0;


    void Awake(){
        GameManager = GameObject.Find("GameManager");
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
            return;
        } else 
            Instance = this;
    }
    
    private void Start()
    {
        Spawn();
    }

    //This gets the currentWave from game manager and times it by 2 to get the number of enemies to spawn
    private void Spawn(){
        int waveEnemies = GameManager.GetComponent<GameManager>().currentWave * 2;
        while(currentEnemies < waveEnemies){
            WaitForSeconds(spawnDelay);
            currentEnemies++;
            Debug.Log("Current enemies: " + currentEnemies);
        }
    }

    //spawn delay for spawning enemies
    private void WaitForSeconds(float spawnDelay)
    {
        Debug.Log("Waiting for " + spawnDelay + " seconds");
        int index = Random.Range(0, spawnPonints.Length);
        Instantiate(enemyPrefab, spawnPonints[index].position, spawnPonints[index].rotation);
    }
}
