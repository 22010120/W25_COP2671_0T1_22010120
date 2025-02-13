using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [Header("Variables")]
    public float rotationSpeed;

    void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
