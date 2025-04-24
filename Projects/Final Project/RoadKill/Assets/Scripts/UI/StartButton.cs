using UnityEngine;

public class StartButton : MonoBehaviour
{
    private GameManager gameManager;

    void start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void startButton(){
        gameManager.StartGame();
    }
}
