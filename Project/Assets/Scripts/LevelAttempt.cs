using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAttempt : MonoBehaviour
{

    public GameObject L1;
    public GameObject L2;
    public GameObject L3;
    public GameObject L4;
    public GameObject L5;
    public GameObject L6;
    public GameObject L6book;
    public GameObject Imp;

    // Start is called before the first frame update
    void Start()
    {
        Lv2();
        Lv3();
        Lv4();
        Lv5();
        Lv6();
        Book();
        PlayerPrefs.GetInt("lv2", 0);
        PlayerPrefs.GetInt("lv3", 0);
        PlayerPrefs.GetInt("lv4", 0);
        PlayerPrefs.GetInt("lv5", 0);
        PlayerPrefs.GetInt("lv6", 0);
        PlayerPrefs.GetInt("Book", 0);
       




    }

   void Lv2()
    {
        L2.gameObject.SetActive(PlayerPrefs.GetInt("lv2") >= 2);

    }

    void Lv3()
    {
        L3.gameObject.SetActive(PlayerPrefs.GetInt("lv3") >= 3);
    }


    void Lv4()
    {
        L4.gameObject.SetActive(PlayerPrefs.GetInt("lv4") >= 4);
    }

    void Lv5()
    {
        L5.gameObject.SetActive(PlayerPrefs.GetInt("lv5") >= 5);
    }

    void Lv6()
    {
        L6.gameObject.SetActive(PlayerPrefs.GetInt("lv6") >= 6);
        
    }

    void Book()
    {
       
        L6book.gameObject.SetActive(PlayerPrefs.GetInt("Book") >= 7);
        Imp.gameObject.SetActive(PlayerPrefs.GetInt("Book") >= 7);
    }

    public void Lv1Click()
    {

        PlayerPrefs.SetInt("lv2", 2);
        PlayerPrefs.Save();
        Lv2();
        Lv3();
        Lv4();
        Lv5();
        Lv6();
        Book();



    }

    public void Lv2Click()
    {

        PlayerPrefs.SetInt("lv3", 3);
        PlayerPrefs.Save();
        Lv2();
        Lv3();
        Lv4();
        Lv5();
        Lv6();
        Book();
    }

    public void Lv3Click()
    {

        PlayerPrefs.SetInt("lv4", 4);
        PlayerPrefs.Save();
        Lv2();
        Lv3();
        Lv4();
        Lv5();
        Lv6();
        Book();

    }

    public void Lv4Click()
    {

        PlayerPrefs.SetInt("lv5", 5);
        PlayerPrefs.Save();
        Lv2();
        Lv3();
        Lv4();
        Lv5();
        Lv6();
        Book();

    }

    public void Lv5Click()
    {

        PlayerPrefs.SetInt("lv6", 6);
        PlayerPrefs.Save();
        Lv2();
        Lv3();
        Lv4();
        Lv5();
        Lv6();
        Book();

    }

    public void Lv6Click()
    {

        PlayerPrefs.SetInt("Book", 7);
        PlayerPrefs.Save();
        Lv2();
        Lv3();
        Lv4();
        Lv5();
        Lv6();
        Book();

    }
}
