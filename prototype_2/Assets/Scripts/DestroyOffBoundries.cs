using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffBoundries : MonoBehaviour
{

    private float topBound = 40;
    private float lowerBound = -20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject); // destroys current object when out of bounds
        }
        else if (transform.position.z < lowerBound){
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
//lorran
