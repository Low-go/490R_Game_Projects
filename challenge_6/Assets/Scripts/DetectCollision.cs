using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // This function runs when the projectile collides with another object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(other.gameObject);
            // Optionally, destroy the projectile too
            Destroy(gameObject);
        }
    }
}
