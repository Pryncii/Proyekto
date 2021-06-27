using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public GameObject Levelselect;
        public GameObject close;

  public void begin()
    {
        Levelselect.SetActive(true);
        close.SetActive(false);
        
    }
}
