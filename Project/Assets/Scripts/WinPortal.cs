using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPortal : MonoBehaviour
{

    public float speed;
    public GameObject Win;
    public GameObject scoring;

    // Start is called before the first frame update
    void Start()
    {
        scoring = FindObjectOfType<ScoreManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            Win.SetActive(true);
            Time.timeScale = 0;
            ScoreManager Total = scoring.GetComponent<ScoreManager>();

            PlayerPrefs.SetInt("TotalScore", Total.Totalscored += Total.score);
        }

    }
        }
