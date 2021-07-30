using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeed : MonoBehaviour
{
    public GameObject effect;
    public float speed;
    public int duration;
    public AudioSource begin;
    public AudioSource end;
    public GameObject Coffee;


    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (PlayerPrefs.GetInt("coff", 0) == 1)
        {
            Coffee = FindObjectOfType<coffee>().gameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("coff", 0) == 1)
            {
                coffee Total = Coffee.GetComponent<coffee>();

                Total.startattack -= 1;
            }
            other.GetComponent<Player>().startattack -= 1;
            Debug.Log(other.GetComponent<Player>().damage);
            Instantiate(effect, transform.position, Quaternion.identity);
            begin.Play();
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            if(other != null)
            {
                StartCoroutine(Normal(other));
            }
        }



    }


    IEnumerator Normal(Collider2D other)
    {
       
            yield return new WaitForSeconds(10f);
        if (other != null)
        {
            coffee Total = Coffee.GetComponent<coffee>();

            Total.startattack += 1;
            other.GetComponent<Player>().startattack += 1;
            Debug.Log(other.GetComponent<Player>().damage);
            end.Play();
        }
        

    }
}

