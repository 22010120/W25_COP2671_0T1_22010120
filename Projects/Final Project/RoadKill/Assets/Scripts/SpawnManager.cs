using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance { get; private set; }
    public GameObject enemyPrefab;
    public Transform[] spawnPonints;
    public float currentEnemies = 0;
    public float maxEnemies = 5;

    void Awake(){
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

    private void Spawn(){
        while(currentEnemies < maxEnemies){
            int index = Random.Range(0, spawnPonints.Length);
            Instantiate(enemyPrefab, spawnPonints[index].position, spawnPonints[index].rotation);
            currentEnemies++;
        }
        
    }
}
