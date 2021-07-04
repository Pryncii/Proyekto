using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlezz : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("Endless");
        GetComponent<AudioSource>().Play();
    }
}
