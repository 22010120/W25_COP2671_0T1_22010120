using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player; // Reference to the player object
    public GameObject GameManager; // Reference to the game manager object
    public int damage = 10; // Damage dealt by the enemy
    public int health = 100; // Health of the enemy
    public int speed = 3; // Speed of the enemy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player"); // Find the player object in the scene
        GameManager = GameObject.Find("GameManager"); // Find the game manager object in the scene
        
    }

    public void TakeDamage(int playerDamage){
        health -= playerDamage; // Reduce enemy health by the player's damage
        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        Debug.Log("Enemy has died."); // Add money to the game manager when the enemy dies
        Destroy(gameObject); // Destroy the enemy object
    }
}
