using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameObject open;
    public GameObject close;
    public GameObject dmg1;
    public GameObject dmg2;
    public GameObject spd1;
    public GameObject spd2;
    public GameObject spspd1;
    public GameObject spspd2;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject c1;
    public GameObject c2;





    void Start()
    {
        HideAndShowButtons();
        HideAndShowButtonsdmg();
        HideAndShowButtonsspd();
        HideAndShowButtonspspd();
        HideAndShowButtonhp();
        HideAndShowButtoncoffee();

        PlayerPrefs.GetInt("HiddenButton", 1);
        PlayerPrefs.GetInt("HidButton", 1);
        PlayerPrefs.GetInt("spdButton", 1);
        PlayerPrefs.GetInt("spspdButton", 1);
        PlayerPrefs.GetInt("hpButton", 1);
        PlayerPrefs.GetInt("coff", 0);
    }
    void HideAndShowButtons()
    {
        open.gameObject.SetActive(PlayerPrefs.GetInt("HiddenButton", 1) != 1);
        close.gameObject.SetActive(PlayerPrefs.GetInt("HiddenButton", 1) != 2);
        
    }

    void HideAndShowButtonsdmg()
    {
        dmg1.gameObject.SetActive(PlayerPrefs.GetInt("HidButton", 1) != 1);
        dmg2.gameObject.SetActive(PlayerPrefs.GetInt("HidButton", 1) != 2);
    }

    void HideAndShowButtonsspd()
    {
        spd1.gameObject.SetActive(PlayerPrefs.GetInt("spdButton", 1) != 1);
        spd2.gameObject.SetActive(PlayerPrefs.GetInt("spdButton", 1) != 2);
    }


    void HideAndShowButtonspspd()
    {
        spspd1.gameObject.SetActive(PlayerPrefs.GetInt("spspdButton", 1) != 1);
        spspd2.gameObject.SetActive(PlayerPrefs.GetInt("spspdButton", 1) != 2);
    }

    void HideAndShowButtonhp()
    {
        hp1.gameObject.SetActive(PlayerPrefs.GetInt("hpButton", 1) != 1);
        hp2.gameObject.SetActive(PlayerPrefs.GetInt("hpButton", 1) != 2);
    }

    void HideAndShowButtoncoffee()
    {
        c1.gameObject.SetActive(PlayerPrefs.GetInt("coff", 0) == -1);
        c2.gameObject.SetActive(PlayerPrefs.GetInt("coff", 0) == 1);
    }

    public void Healthwhenclickbutton1()
    {
        
            PlayerPrefs.SetInt("HiddenButton", 1);
            PlayerPrefs.Save();
            HideAndShowButtons();
        
    }
    public void Healthwhenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 1000)
        {
            PlayerPrefs.SetInt("HiddenButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtons();
        }
    }

    public void Damagewhenclickbutton1()
    {
        
            PlayerPrefs.SetInt("HidButton", 1);
            PlayerPrefs.Save();
            HideAndShowButtonsdmg();
        
    }
    public void Damagewhenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 3000)
        {
            PlayerPrefs.SetInt("HidButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtonsdmg();
        }
    }

    public void Speedwhenclickbutton1()
    {
        
            PlayerPrefs.SetInt("spdButton", 1);
            PlayerPrefs.Save();
        HideAndShowButtonsspd();


    }
    public void Speedwhenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 5000)
        {
            PlayerPrefs.SetInt("spdButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtonsspd();
        }
    }

    public void Specialwhenclickbutton1()
    {
       
            PlayerPrefs.SetInt("spspdButton", 1);
            PlayerPrefs.Save();
            HideAndShowButtonspspd();
        
    }
    public void Specialwhenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 10000)
        {
            PlayerPrefs.SetInt("spspdButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtonspspd();
        }
    }

    public void Health2whenclickbutton1()
    {
        
            PlayerPrefs.SetInt("hpButton", 1);
            PlayerPrefs.Save();
            HideAndShowButtonhp();
        
    }
    public void Health2whenclickbutton2()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 20000)
        {
            PlayerPrefs.SetInt("hpButton", 2);
            PlayerPrefs.Save();
            HideAndShowButtonhp();
        }
    }

    public void Coffeewhenclickbutton1()
    {

        PlayerPrefs.SetInt("coff", 1);
        PlayerPrefs.Save();
        HideAndShowButtoncoffee();

    }
    public void Coffeewhenclickbutton2()
    {
        
            PlayerPrefs.SetInt("coff", -1);
            PlayerPrefs.Save();
            HideAndShowButtoncoffee();
        
    }
}
