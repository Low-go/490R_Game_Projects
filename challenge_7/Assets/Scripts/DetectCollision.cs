using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject gameManagerObject;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //call function to increase game score
            gameManager.AddScore();
            Destroy(gameObject); // destroy bullet
        }
        else if (other.CompareTag("Good"))
        {
            //call fucntion to lose points
            gameManager.DeleteScore();
            Destroy(gameObject);
        }
    }
}
