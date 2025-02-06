using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("References")]
    public GameObject obstaclePrefab;

    [Header("Variables")]
    public Vector3 spawnPos = new Vector3(25,0,0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
