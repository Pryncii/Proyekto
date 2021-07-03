using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public Text scoreDisplay;
    public Text scoredDisplay;
    public Text highScore;
    public Text highScored;

    void Update()
    {
        scoreDisplay.text = score.ToString();
        scoredDisplay.text = score.ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScored.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            score++;
            Debug.Log(score);
            if(score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                    highScore.text = score.ToString();
            }
        }

    }

}
