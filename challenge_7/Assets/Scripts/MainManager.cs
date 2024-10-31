using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public int currentScore = 0;  // This will persist between scenes


    private void Awake()
    {
        // Proper singleton pattern to ensure only one instance exists
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("MainManager initialized with score: " + currentScore);

    }

    // following methods will ensure information is passed between scenes
    public void SaveScore(int score)
    {
        currentScore = score;
        Debug.Log("Score saved in MainManager: " + currentScore);
    }


}