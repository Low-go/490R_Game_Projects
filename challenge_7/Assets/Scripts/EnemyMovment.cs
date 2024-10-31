using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    public float speed = 3.0f;
    private Rigidbody rb;

    void Start()
    {
        Debug.Log("Enemy Start called");
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();

        // Configure Rigidbody settings
        if (rb != null)
        {
            rb.freezeRotation = true;  // Prevent tipping over
            rb.constraints = RigidbodyConstraints.FreezeRotation; // Alternative to freeze rotation
            rb.isKinematic = false;    // Make sure physics affects it
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Better collision detection
        }
    }

    void FixedUpdate()  // Use FixedUpdate for physics!
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            // Use physics movement instead of transform
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}
