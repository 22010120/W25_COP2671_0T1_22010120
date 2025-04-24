using TMPro;    
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float startTime = 60f;
    public float currentTime; //tracks the remainign time
    public TextMeshProUGUI Timer;
    private GameManager gameManager; //GameManager reference for gameover

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentTime = startTime; // Initialize current time to start time
    }

    void Update()
    {
        currentTime -= Time.deltaTime; //decrease the timer
        if (currentTime <= 0)
        {
            currentTime = 0; // Set current time to 0 when it reaches 0
            gameManager.GameOver(); // Call GameOver function when the timer reaches 0
        }
        TimerUI(); // Call the TimerUI function to update the UI
    }

    void TimerUI()
    {
        int seconds = Mathf.FloorToInt(currentTime % 60); // Calculate seconds
        Timer.text = string.Format("Time Remaining: {00}", seconds); // Update the timer text in the UI
    }
}
