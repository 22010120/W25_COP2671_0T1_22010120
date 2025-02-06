using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("References")]
    public GameObject obstaclePrefab;

    [Header("Variables")]
    public Vector3 spawnPos = new Vector3(25,0,0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;

    [Header("References")]
    private PlayerController playerControllerScript;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false){
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}
