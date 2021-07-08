using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public int Totalscored;
    public Text scoreDisplay;
    public Text scoredDisplay;
    public Text winscoredDisplay;
    public Text highScore;
    public Text highScored;
    public Text winhighScored;
    public Text totalScore;
    public GameObject Player;

   void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
       Totalscored = PlayerPrefs.GetInt("TotalScore", 0);
        PlayerPrefs.GetInt("TotalScore", 0);
    }

    void Update()
    {
        scoreDisplay.text = score.ToString();
        scoredDisplay.text = score.ToString();
        winscoredDisplay.text = score.ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScored.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        winhighScored.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        totalScore.text = PlayerPrefs.GetInt("TotalScore", 0).ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        }


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
                highScored.text = score.ToString();
                winhighScored.text = score.ToString();
            }
        }

    }

}
