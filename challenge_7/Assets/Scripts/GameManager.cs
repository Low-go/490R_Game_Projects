using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score = 0;
    public TextMeshProUGUI scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void UpdateScore()
    {
        scoreBoard.text = "Score: " + score.ToString();
    }

    public void AddScore()
    {
        score += 15;
        UpdateScore();
    }

    public void DeleteScore()
    {
        //check if the score is below to avoid negative scores
        if (score <= 15)
        {
            score = 0;
            UpdateScore();
        }
        else
        {
            score = -score;
            UpdateScore();
        }
    }

    
}
