using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private string gameSceneName = "MainScene";


    public void OnQuickStart()
    {
        SceneManager.LoadScene(gameSceneName);
    }

}
