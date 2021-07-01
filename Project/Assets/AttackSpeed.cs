using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeed : MonoBehaviour
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

            other.GetComponent<Player>().startattack -= 1;
            Debug.Log(other.GetComponent<Player>().damage);
            Instantiate(effect, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            StartCoroutine(Normal(other));

        }



    }


    IEnumerator Normal(Collider2D other)
    {
        yield return new WaitForSeconds(10f);
        other.GetComponent<Player>().startattack += 1;
        Debug.Log(other.GetComponent<Player>().damage);
        GetComponent<AudioSource>().Play();

    }
}

