using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sett : MonoBehaviour
{
    public GameObject Button;
    public GameObject ButtonCon;
    public GameObject close;

    public void begin()
    {
        Button.SetActive(true);
        ButtonCon.SetActive(true);
        close.SetActive(false);

    }
}
