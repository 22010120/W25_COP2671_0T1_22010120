using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [Header("Variables")]
    public float speed = 30.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
