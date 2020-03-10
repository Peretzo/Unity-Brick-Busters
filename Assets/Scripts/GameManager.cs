using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private BallController theBall;
    public bool gameActive;
    public Text livesText, scoreText;
    public int lives=3;
    public GameObject gameOverScreen, pauseScreen, levelWin;
    public int currentScore;
    public Text hiScore;
    public int currentHiScore;


    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<BallController>();
        currentScore = PlayerPrefs.GetInt("currentScore");
        scoreText.text = "Score: " + currentScore;
        lives = PlayerPrefs.GetInt("currentLives");
        livesText.text = "Lives: " + lives;
        currentHiScore = PlayerPrefs.GetInt("highScore");
        hiScore.text = "High Score:" + currentHiScore;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !gameActive)
        {
            theBall.ActivateBall();
            gameActive = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (pauseScreen.activeSelf)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
        var brickCheck = FindObjectOfType<BrickController>();
        if(brickCheck == null)
        {
            PlayerPrefs.SetInt("currentScore", currentScore);
            PlayerPrefs.SetInt("highScore", currentHiScore);
            levelWin.SetActive(true);
            Time.timeScale = 0f;
        }


    }

    public void RespawnBall()
    {
        gameActive = false;
        lives--;
        livesText.text = "Lives: " + lives;
        if (lives == 0)
        {
            theBall.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            PlayerPrefs.SetInt("highScore", currentHiScore);
        }
        PlayerPrefs.SetInt("currentLives", lives);
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = "Score: " + currentScore;
        if (currentScore >= currentHiScore)
        {
            currentHiScore = currentScore;
            hiScore.text = "High Score:" + currentHiScore;
        }
    }
}
