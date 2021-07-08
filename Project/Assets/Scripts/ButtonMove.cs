using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMove : MonoBehaviour
{
   
    public GameObject close;
    public GameObject Button;

    void Start()
    {
        Button = GameObject.FindGameObjectWithTag("ButtonControl");
    }
    public void begin()
    {
        

        Button.SetActive(true);
        close.SetActive(false);

    }
}
