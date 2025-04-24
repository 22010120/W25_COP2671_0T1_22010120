using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStats : MonoBehaviour
{

    public GameObject GameManager;
    public GameObject EnemyPrefab;
    public TextMeshProUGUI Score;

    [Header("Stats")]
    public int health = 100;
    public int damage = 10;
    public int speed = 5;
    public int armor = 0;
    public int level = 1;
    public int experience = 0;
    public int money = 0;

    void Start() {
        GameManager = GameObject.Find("GameManager"); // used to talk to the game manager
        EnemyPrefab = GameObject.Find("EnemyPrefab");// used to talk to the enemy prefab
     
    }

    //looks at the enemy prefab and gets the damage value from it
    public void TakeDamage(int enemyDamage) {
        health -= enemyDamage;
        if (health <= 0) {
            Die();
        }
    }

    public void AddMoney(int amount) {
        money += amount;
        Score.text = string.Format("Money: ${money}", money);
    }

    public void Die() {
        Debug.Log("Player has died.");
        GameManager.GetComponent<GameManager>().GameOver();
    }
}
