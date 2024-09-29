using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //gets the player and their player controller object.
    }                                                                                        // basically we wnat the exisiting script and not our own

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) // so it is not game over yet so its allowed to move
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        if ( transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
//lorran    