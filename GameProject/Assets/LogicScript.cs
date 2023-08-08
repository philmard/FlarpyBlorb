using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public int highScore; // an int for high score
    public Text highScoreText; // and a text
    public GameObject gameOverScreen;
    public GameObject gameStartScreen;
    public AudioSource dingSFX;

    void Start()
    {
        // load high score when starting a new game
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString(); // (?) highScoreText.text or plain highScoreText (?)
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        //Debug.Log("ADDING SCORE!");
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        dingSFX.Play();        
    }
    public void updateHighScore(int newHighScore)
    {
        highScore = newHighScore;
        highScoreText.text = highScore.ToString(); // (?) highScoreText.text or plain highScoreText (?)
        // also do this to keep the high score on the hard drive:
        Debug.Log("High Score Saved!");
        PlayerPrefs.SetInt("HighScore", newHighScore);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void gameStart()
    {
        gameStartScreen.SetActive(false);
    }

    public void Reset() // isnt implemented yet
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
