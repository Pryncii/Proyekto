using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void begin()
    {
        SceneManager.LoadScene("Level 1");
        
    }
}
