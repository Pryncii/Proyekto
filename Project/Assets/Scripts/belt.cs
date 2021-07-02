using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class belt : MonoBehaviour
{
    public GameObject effect;
    public float speed;
    public int duration;
    

    void Update()
    {
       
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<BoxCollider2D>().enabled = false;
            other.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            Instantiate(effect, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            StartCoroutine(Normal(other));

        }

     


    }


    IEnumerator Normal(Collider2D other)
    {
        yield return new WaitForSeconds(duration);
       other.GetComponent<BoxCollider2D>().enabled = true;
        other.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        Debug.Log(other.GetComponent<Player>().damage);
    }
}
