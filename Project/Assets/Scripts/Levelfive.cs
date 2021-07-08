using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelfive : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene("Level 5");
        GetComponent<AudioSource>().Play();
    }

}
