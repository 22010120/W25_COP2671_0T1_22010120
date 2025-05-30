using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    private float baseSpeed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private GameManager gameManager;

    void Start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update(){
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move the player
        transform.Translate(Vector3.forward * Time.deltaTime * baseSpeed * forwardInput);

        // Rotate the player only when moving
        if (forwardInput != 0)
        {
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
        if(transform.position.y <= -3f){
            gameManager.GameOver();
        }
    }

}