using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //vars
    public int animalIndex;
    //objects
    public GameObject[] animalPrefabs;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            Instantiate(animalPrefabs[animalIndex], new Vector3(0,0,20),
            animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
