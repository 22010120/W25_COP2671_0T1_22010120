
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int currentWave;
    public int score;
    public bool isGameStarted = false;//game start state
    public bool isGamePaused = false; //game pause state
    public GameObject MainMenu; 
    public GameObject PauseMenu;
    public GameObject Timer;
    public GameObject HealthBar;
    public GameObject Score;
    private WaveManager waveManager;
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

    void Start(){
        waveManager = GetComponent<WaveManager>();
    }

    private void Update(){

        if (!isGameStarted) return;

        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    private void TogglePause()
    {
        //Only toggle pause if the game has started
        if (isGameStarted)
        {
            isGamePaused = !isGamePaused; // Flips the pause state to whatever it is not
            Time.timeScale = !isGamePaused ? 1f : 0f; //if the game is paused, set the time scale to 0, otherwise set it to 1
            PauseMenu.SetActive(isGamePaused); // Show the pause menu if the game is paused, otherwise hide it
        }
    }
    public void StartGame()
    {
        MainMenu.gameObject.SetActive(false);
        Timer.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
        HealthBar.gameObject.SetActive(true);
        isGameStarted = true;
        Time.timeScale = 1f; //Starts game time scale
        //Resets the game variables if restarting
        score = 0;
        currentWave = 1;
        Debug.Log("Game Started");
        waveManager.publicStart();
    }
    public void GameOver()
    {
        isGameStarted = false;
        isGamePaused = false;
        Time.timeScale = 0f; //stops the game
        MainMenu.gameObject.SetActive(true); //Goes back to the main menu and lets the player restart the game
        Debug.Log("Game Over");
    }
}
