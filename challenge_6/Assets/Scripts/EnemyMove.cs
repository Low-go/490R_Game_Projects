using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform player;  
    private float speed = 7.5f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        // Move the enemy towards the player
        transform.position += direction * speed * Time.deltaTime;

        // Optional: Make the enemy face the player
        transform.LookAt(player);
    }
}
