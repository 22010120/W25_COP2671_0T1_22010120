using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int currentWave;
    public int score;
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            Instance = this;
            StartGame();
    }
    public void StartGame()
    {
        score = 0;
        currentWave = 1;
        Debug.Log("Game Started");
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
