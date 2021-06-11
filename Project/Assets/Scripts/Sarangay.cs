using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarangay : MonoBehaviour
{

    public int duration;
    public GameObject charge;
    private float wait;
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        wait = 1;
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(wait > 0)
        {
            wait -= Time.deltaTime;
        }

        if (wait <= 0)
        {
            charge = (GameObject)Instantiate(charge, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
