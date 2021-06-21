using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("Level 2");
        GetComponent<AudioSource>().Play();
    }
}
