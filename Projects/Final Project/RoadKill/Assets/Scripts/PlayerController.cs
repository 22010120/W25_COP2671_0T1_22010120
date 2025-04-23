using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float baseSpeed  = 20f;
    [SerializeField] float turnSpeed  = 45f;
    Rigidbody rb;
    float h, v;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        // prevent tipping
        rb.constraints = RigidbodyConstraints.FreezeRotationX 
                       | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update() {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        // 1) forward/backward
        Vector3 dir = transform.forward * v;
        dir.y = 0;              // keep on ground plane
        dir.Normalize();
        Vector3 move = dir * baseSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // 2) turning
        if (v != 0) {
            float turn = h * turnSpeed * Time.fixedDeltaTime;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turn, 0));
        }
    }
}
