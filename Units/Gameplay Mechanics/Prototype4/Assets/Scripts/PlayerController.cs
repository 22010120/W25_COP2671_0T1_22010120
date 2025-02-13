using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    public float speed = 5.0f;

    [Header("References")]
    private Rigidbody playerRb;
    private GameObject focalPoint;

    void Start(){
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    void Update(){
        float forwardIput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardIput);
    }
}
