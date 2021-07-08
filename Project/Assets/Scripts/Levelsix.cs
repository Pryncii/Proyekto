using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelsix : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("Level 6");
        GetComponent<AudioSource>().Play();
    }
}
