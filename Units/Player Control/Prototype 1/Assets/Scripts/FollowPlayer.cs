using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //Objects
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
       transform.position =  player.transform.position + new Vector3(0, 5, -7); //follows player object as it moves
    }
}
