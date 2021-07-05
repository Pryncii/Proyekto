using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RESET : MonoBehaviour
{
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
