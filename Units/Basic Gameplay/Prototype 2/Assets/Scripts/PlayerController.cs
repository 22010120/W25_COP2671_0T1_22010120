using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // vars
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;

    // Objects
    public GameObject projectilePrefab;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // Gets input from user for left and right movements
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed); // Moves Player the direction of horizontalInput.

        // Keeps the player inbounds
        if (transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            //Launce a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
