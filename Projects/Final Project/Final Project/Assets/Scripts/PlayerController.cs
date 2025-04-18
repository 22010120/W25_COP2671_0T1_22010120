using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    private float speed = 20.0f;
    private float turnSpeed = 1000.0f;
    private float horizontalInput;
    private float forwardInput;
    private Vector3 moveDirection;

    [Header("References")]
    public Transform cameraTarget;

    [Header("Objects")]
    private CharacterController characterController;

    void Start(){
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {   

        float horizontal = horizontalInput = Input.GetAxis("Horizontal"); // A, D
        float vertical = forwardInput = Input.GetAxis("Vertical"); // W, S

        Vector3 forward = cameraTarget.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = cameraTarget.right;
        right.y = 0;
        right.Normalize();

        moveDirection = (forward * vertical+ right * horizontal).normalized;


        characterController.Move(moveDirection * speed * Time.deltaTime);

        HandleRotation();
    }
    void HandleRotation(){
        float mouseX = Input.GetAxis("Mouse X");

        if (Mathf.Abs(mouseX) > 0.01f){
            transform.Rotate(Vector3.up, mouseX * turnSpeed * Time.deltaTime);
        }
    }
}
