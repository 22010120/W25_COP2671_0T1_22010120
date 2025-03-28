using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public enum ZoneType { FrontBack, Side }
    public ZoneType zoneType;


    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        PlayerStats player = GetComponent<PlayerStats>();
        Debug.Log("Player collided with: " + other.gameObject.name);

        if(enemy != null){
            
        
            if(zoneType == ZoneType.FrontBack){
                enemy.TakeDamage(player.damage);
                if(enemy.health <= 0) {
                    Destroy(other.gameObject);
                } else {
                    Debug.Log("Enemy has been damaged. Remaining health: " + enemy.health);
                }
                
            }
            else if (zoneType == ZoneType.Side){
                //this zone damages the player
                Debug.Log("Player has been damaged");
                if (player != null)
                {
                    player.TakeDamage(enemy.damage); // Assuming enemy has a damage property
                }
                else
                {
                    Debug.LogError("PlayerStats component not found on the player object.");
                }
            }
        }
    }
}