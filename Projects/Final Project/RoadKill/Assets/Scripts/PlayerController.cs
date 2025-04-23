using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float baseSpeed  = 20f;
    [SerializeField] float turnSpeed  = 45f;
    Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        Vector3 newPosition = transform.position + movement * baseSpeed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);


        // 2) turning
        if (verticalInput != 0) {
            float turn = horizontalInput * turnSpeed * Time.fixedDeltaTime;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turn, 0));
        }
    }
}
