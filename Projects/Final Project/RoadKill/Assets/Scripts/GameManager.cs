using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int currentWave;
    public int score;
    public bool isGameStarted = false;    
    void Awake()
    {

        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            Instance = this;
            Time.timeScale = 0f; // Pause the game at the start
    }

    private void Update(){

        if (!isGameStarted) return;

        //if (Input.GetKeyDown(KeyCode.Escape))
            //TogglePause();
    }
    public void StartGame()
    {
        isGameStarted = true;
        Time.timeScale = 1f; // Resume the game
        score = 0;
        currentWave = 1;
        Debug.Log("Game Started");
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
