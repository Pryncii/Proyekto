using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgup : MonoBehaviour
{
    public GameObject Windblade;
    public GameObject Lava;
    public GameObject Water;
    public GameObject Shadow;



    void Start()
    {
        HideAndShowButtons();
    }
    void HideAndShowButtons()
    {
        Windblade.gameObject.SetActive(PlayerPrefs.GetInt("Special") != 1);
        Lava.gameObject.SetActive(PlayerPrefs.GetInt("Special") != 2);
        Water.gameObject.SetActive(PlayerPrefs.GetInt("Special") != 3);
        Shadow.gameObject.SetActive(PlayerPrefs.GetInt("Special") != 4);
       
    }

    public void wind()
    {
        if (PlayerPrefs.GetInt("HighScore", 0) >= 100)
        {
            PlayerPrefs.SetInt("Special", 1);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }

    }
    public void Lav()
    {
        if (PlayerPrefs.GetInt("HighScore", 0) >= 300)
        {
            PlayerPrefs.SetInt("Special", 2);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }
    }

    public void Waters()
    {
        if (PlayerPrefs.GetInt("HighScore", 0) >= 600)
        {
            PlayerPrefs.SetInt("Special", 3);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }
    }

    public void Shadows()
    {
        if (PlayerPrefs.GetInt("HighScore", 0) >= 1000)
        {
            PlayerPrefs.SetInt("Special", 4);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }
    }
}
