using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menunu : MonoBehaviour
{
    public GameObject scoring;
    void Start()
    {
        scoring = FindObjectOfType<ScoreManager>().gameObject;
    }
    public void begin()
    {
        SceneManager.LoadScene("Menu");
        GetComponent<AudioSource>().Play();
        ScoreManager Total = scoring.GetComponent<ScoreManager>();

        PlayerPrefs.SetInt("TotalScore", Total.Totalscored += Total.score);
    }

    public void win()
    {
        SceneManager.LoadScene("Menu");
        GetComponent<AudioSource>().Play();
       
    }
}
