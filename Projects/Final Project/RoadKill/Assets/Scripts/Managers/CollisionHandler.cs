using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public enum ZoneType { FrontBack, Side } //list of zone types
    public ZoneType zoneType; // the type of zone this object is

    public GameObject player; // reference to the player object
    public GameObject enemy; // reference to the enemy object

    public GameObject gameManager; // reference to the game manager object

    void Start()
    {
        player = GameObject.Find("Player"); // finds the player object in the scene
        enemy = GameObject.Find("EnemyPrefab"); // finds the enemy prefab in the scene
        gameManager = GameObject.Find("GameManager"); // finds the game manager object in the scene
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>(); // gets the enemy component from the object that collided with this object
        PlayerStats player = GetComponentInParent<PlayerStats>(); // gets the player component from this object

        if(enemy != null){
            Vector3 direction = (enemy.transform.position - transform.position).normalized;
            if(zoneType == ZoneType.FrontBack)
            {
                enemy.TakeDamage(player.damage);// calls the TakeDamage function from the enemy script and passes in the players damage value
                
                Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>(); // gets the rigidbody component from the enemy object
                
                float knockbackForce = 15f;
                enemyRigidbody.AddForce(direction * knockbackForce, ForceMode.Impulse);
                
                StartCoroutine(StopEnemyMovement(enemyRigidbody, 0.5f)); // stops the enemy movement for 1 second
                //if that enemy has 0 health, destroy it
                if(enemy.health <= 0) {
                    Destroy(other.gameObject);
                } else {
                }
                
            }
            
            else if (zoneType == ZoneType.Side){
                //this zone damages the player
                if (player != null)
                {
                    player.TakeDamage(enemy.damage); // calls the TakeDamage function from the player script and passes in the enemies damage value
                }
                else
                {

                }
            }
        }
    }

    private IEnumerator StopEnemyMovement(Rigidbody enemyRigidbody, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(enemyRigidbody != null){
            enemyRigidbody.linearVelocity = Vector3.zero; // Stop the enemy's movement
            enemyRigidbody.angularVelocity = Vector3.zero; // Stop any rotation
        }
        
    }
}