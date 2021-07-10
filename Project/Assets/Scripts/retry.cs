using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
    public GameObject scoring;
    void Start()
    {
        scoring = FindObjectOfType<ScoreManager>().gameObject;
    }

    public void begin()
    {
       
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreManager Total = scoring.GetComponent<ScoreManager>();

        PlayerPrefs.SetInt("TotalScore", Total.Totalscored += Total.score);
    }
}
