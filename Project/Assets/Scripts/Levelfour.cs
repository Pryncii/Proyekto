using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelfour : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("Level 4");
        GetComponent<AudioSource>().Play();
    }
}
