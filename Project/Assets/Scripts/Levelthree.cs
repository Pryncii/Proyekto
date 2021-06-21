using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelthree : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("Level 3");
        GetComponent<AudioSource>().Play();
    }
}
