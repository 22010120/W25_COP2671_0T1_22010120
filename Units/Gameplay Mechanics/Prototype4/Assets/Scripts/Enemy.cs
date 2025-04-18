using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Variables")]
    public float speed;
   
    [Header("References")]
    private Rigidbody enemyRb;
    private GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        if (transform.position.y < -10.0f) {
            Destroy(gameObject);
        }
    }
}
