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
   
    // Start is called before the first frame update
    void Start()
    {
        Lv2();
        Lv3();
        Lv4();
        Lv5();
        Lv6();
       




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

    public void Lv1Click()
    {

        PlayerPrefs.SetInt("lv2", 2);
        PlayerPrefs.Save();
        Lv2();
        Lv3();
        Lv4();
        Lv5();
        Lv6();



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

    }
}
