using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public enum ZoneType { FrontBack, Side }
    public ZoneType zoneType;


    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        Debug.Log("Player collided with: " + other.gameObject.name);
        if(enemy != null){
            
        
            if(zoneType == ZoneType.FrontBack){
                //this zone damages the enemy
                Destroy(other.gameObject);
                Debug.Log("enemy destroyed");
            }
            else if (zoneType == ZoneType.Side){
                //this zone damages the player
                Debug.Log("Player has been damaged");
            }
        }
    }
}