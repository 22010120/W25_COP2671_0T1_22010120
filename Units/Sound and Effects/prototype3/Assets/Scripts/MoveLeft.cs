using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [Header("Variables")]
    public float speed = 30.0f;
    private float leftBound = -15.0f;
    [Header("References")]
    private PlayerController playerController;
    void Start() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver == false) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
