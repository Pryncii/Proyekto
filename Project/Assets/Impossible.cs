using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Impossible : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("Impossible");
        GetComponent<AudioSource>().Play();
    }
}