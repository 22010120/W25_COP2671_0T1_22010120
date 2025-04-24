using UnityEngine;

public class StartButton : MonoBehaviour
{
    private GameManager gameManager;

    void start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void startButton(){
        gameManager.StartGame();
    }
}
