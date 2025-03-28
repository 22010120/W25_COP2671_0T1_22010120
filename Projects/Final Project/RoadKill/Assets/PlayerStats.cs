using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public GameObject GameManager;
    public GameObject EnemyPrefab;

    [Header("Stats")]
    public int health = 100;
    public int damage = 10;
    public int speed = 5;
    public int armor = 0;
    public int level = 1;
    public int experience = 0;
    public int money = 0;

    void Start() {
        GameManager = GameObject.Find("GameManager");
        EnemyPrefab = GameObject.Find("EnemyPrefab");
    }

    public void TakeDamage(int enemyDamage) {
        health -= enemyDamage;
        if (health <= 0) {
            Die();
        }
    }

    public void AddMoney(int amount) {
        money += amount;
    }

    public void Die() {
        Debug.Log("Player has died.");
        GameManager.GetComponent<GameManager>().GameOver();
    }
}
