using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player; // Reference to the player object
    private WaveManager waveManager;
    private GameTimer gameTimer;
    public int damage = 10; // Damage dealt by the enemy
    public int health = 10; // Health of the enemy
    public int speed = 3; // Speed of the enemy
    public int worth = 2; // Score zombie gives
    public int addTime = 1; // time zombie kill adds

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player"); // Find the player object in the scene
        waveManager = GameObject.Find("GameManager").GetComponent<WaveManager>();
        gameTimer = GameObject.Find("TimerManager").GetComponent<GameTimer>();
        
    }

    void Update()
    {
        transform.LookAt(Player.transform); // Make the enemy look at the player
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Move the enemy towards the player
    }

    public void TakeDamage(int playerDamage){
        health -= playerDamage; // Reduce enemy health by the player's damage
        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        waveManager.EnemyKill();
        Debug.Log("Enemy has died."); // Add money to the game manager when the enemy dies
        Destroy(gameObject); // Destroy the enemy object
        Player.GetComponent<PlayerStats>().money += worth;
        gameTimer.currentTime += addTime;
    }
}
