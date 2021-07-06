using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameObject open;
    public GameObject close;
  
   

    void Start()
    {
        HideAndShowButtons();
    }
    void HideAndShowButtons()
    {
        open.gameObject.SetActive(PlayerPrefs.GetInt("HiddenButton") != 1);
        close.gameObject.SetActive(PlayerPrefs.GetInt("HiddenButton") != 2);
    }

    public void Genwhenclickbutton1()
    {

        PlayerPrefs.SetInt("HiddenButton", 1);
        PlayerPrefs.Save();
        HideAndShowButtons();

    }
    public void Genwhenclickbutton2()
    {
       
            PlayerPrefs.SetInt("HiddenButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtons();
        
    }


    public void Healthwhenclickbutton1()
    {
        
            PlayerPrefs.SetInt("HiddenButton", 1);
            PlayerPrefs.Save();
            HideAndShowButtons();
        
    }
    public void Healthwhenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 3000)
        {
            PlayerPrefs.SetInt("HiddenButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }
    }

    public void Damagewhenclickbutton1()
    {
        
            PlayerPrefs.SetInt("HiddenButton", 1);
            PlayerPrefs.Save();
            HideAndShowButtons();
        
    }
    public void Damagewhenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 5000)
        {
            PlayerPrefs.SetInt("HiddenButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }
    }

    public void Speedwhenclickbutton1()
    {
        
            PlayerPrefs.SetInt("HiddenButton", 1);
            PlayerPrefs.Save();
            HideAndShowButtons();
        
    }
    public void Speedwhenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 10000)
        {
            PlayerPrefs.SetInt("HiddenButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }
    }

    public void Specialwhenclickbutton1()
    {
       
            PlayerPrefs.SetInt("HiddenButton", 1);
            PlayerPrefs.Save();
            HideAndShowButtons();
        
    }
    public void Specialwhenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 15000)
        {
            PlayerPrefs.SetInt("HiddenButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }
    }

    public void Health2whenclickbutton1()
    {
        
            PlayerPrefs.SetInt("HiddenButton", 1);
            PlayerPrefs.Save();
            HideAndShowButtons();
        
    }
    public void Health2whenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 20000)
        {
            PlayerPrefs.SetInt("HiddenButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }
    }
}
