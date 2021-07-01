using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour
{
    public GameObject effect;
    public float speed;
    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<Player>().health += 25;
            Debug.Log(other.GetComponent<Player>().health);
            Instantiate(effect, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

        }

        if (other.CompareTag("despawn"))
        {
            Destroy(gameObject);
        }

    }

 }
