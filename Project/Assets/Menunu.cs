using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menunu : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("Menu");
        GetComponent<AudioSource>().Play();
    }
}
