using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windblade : MonoBehaviour
{

    public float speed;
    public GameObject jumpy;
    public GameObject scoring;

    // Start is called before the first frame update
    void Start()
    {
        scoring = FindObjectOfType<ScoreManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    transform.Translate(Vector2.right * speed * Time.deltaTime);
}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && CompareTag("Legg"))
        {
            Instantiate(jumpy, transform.position, Quaternion.identity);
            scoring = FindObjectOfType<ScoreManager>().gameObject;

            scoring.gameObject.GetComponent<ScoreManager>().score += 1;
        }

        if (other.CompareTag("leg"))
        {
            Instantiate(jumpy, transform.position, Quaternion.identity);
        }
    }
}
