using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void restartLevel()
    {
        PlayerPrefs.SetInt("currentScore", 0);
        PlayerPrefs.SetInt("currentLives", 3);
        SceneManager.LoadScene("level1");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void quitToMain()
    {
        SceneManager.LoadScene("mainMenuScene");
    }


    
}
