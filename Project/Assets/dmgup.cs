using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgup : MonoBehaviour
{
    public GameObject open;
    public GameObject close;



    void Start()
    {
        HideAndShowButtons();
    }
    void HideAndShowButtons()
    {
        open.gameObject.SetActive(PlayerPrefs.GetInt("dmgButton") != 1);
        close.gameObject.SetActive(PlayerPrefs.GetInt("dmgButton") != 2);
    }

    public void Damagewhenclickbutton1()
    {

        PlayerPrefs.SetInt("dmg", 1);
        PlayerPrefs.Save();
        HideAndShowButtons();

    }
    public void Damagewhenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 5000)
        {
            PlayerPrefs.SetInt("dmg", 2);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }
    }
}
