using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem particleSystem;
    public ParticleSystem dirtSystem;
    public AudioSource playerAudio;

    [Header("Variables")]
    public float jumpForce = 10.0f;
    public float gravityModifier;
    [SerializeField] bool isOnGround = true; //Player starts on ground. Change to false if player starts off ground
    public bool gameOver = false;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtSystem.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
            dirtSystem.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game OVer");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            particleSystem.Play();
            dirtSystem.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

}
