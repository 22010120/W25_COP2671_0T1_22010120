using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody playerRb;

    [Header("Variables")]
    public float jumpForce = 10.0f;
    public float gravityModifier;
    [SerializeField] bool isOnGround = true; //Player starts on ground. Change to false if player starts off ground
    public bool gameOver = false;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game OVer");
        }
    }

}
