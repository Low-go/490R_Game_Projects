using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 20.0f;
    private float turnSpeed = 40.0f; // this will be updated 
    private float horizontalInput;
    private float fowardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the vehicle left or right
        horizontalInput = Input.GetAxis("Horizontal");

        //foward or back
        fowardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * fowardInput);

        // rotates from the front. Movment is based off this rotation, looks more natural
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
