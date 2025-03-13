using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Vector3 moveDirection;

    [Header("References")]
    public Transform cameraTarget;

    [Header("Objects")]
    private CharacterController characterController;

    void Start(){
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   

        float horizontal = horizontalInput = Input.GetAxis("Horizontal"); // A, D
        float vertical = forwardInput = Input.GetAxis("Vertical"); // W, S
        Vector3 forward = cameraTarget.forward;
        Vector3 right = cameraTarget.right;
        forward.y = 0;
        right.y = 0;
        moveDirection = (forward * vertical+ right * horizontal).normalized;
        characterController.Move(moveDirection * speed * Time.deltaTime);

    }
}
