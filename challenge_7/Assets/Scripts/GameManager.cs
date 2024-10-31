using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int score;
    public TextMeshProUGUI timer;
    private float countDownTime = 30f; 
    public TextMeshProUGUI scoreBoard;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance != null)
        {
            score = MainManager.Instance.currentScore;
        }
        gameOverPanel.SetActive(false); // just make it not visible for now
        UpdateScore();
        StartCoroutine(CountDown());
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
            score -= 15;
            UpdateScore();
        }
    }

    private IEnumerator CountDown()
    {
        while (countDownTime > 0)
        {
            timer.text = "Time: " + Mathf.Ceil(countDownTime).ToString();

            //wait a sec
            yield return new WaitForSeconds(1f);

            //decrease timer
            countDownTime--;
        }

        if (MainManager.Instance != null) // save score as global variable in MainManager
        {
            //MainManager.Instance.currentScore = score;  // Save current score
            MainManager.Instance.SaveScore(score);

            //yield return new WaitForSeconds(0.2f);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ShowGameOver();
        }
        else
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }

    }

    private void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Final Score: " + score.ToString();
    }
    
    // methods for the button options
    public void RestartGame()
    {
        SceneManager.LoadScene(0); // Load first scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
