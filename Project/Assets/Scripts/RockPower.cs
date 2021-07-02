using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPower : MonoBehaviour
{
    public GameObject effect;
    public float speed;
    public int duration;
    public AudioSource begin;
    public AudioSource end;


    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<Player>().damage += 100;
            Debug.Log(other.GetComponent<Player>().damage);
            Instantiate(effect, transform.position, Quaternion.identity);
            begin.Play();
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            if (other != null)
            {
                StartCoroutine(Normal(other));
            }
            

        }

      

    }

    
        IEnumerator Normal(Collider2D other)
        {

       
            yield return new WaitForSeconds(duration);
        if (other != null)
        {

            other.GetComponent<Player>().damage -= 100;
            Debug.Log(other.GetComponent<Player>().damage);
            end.Play();
        }
        
    }
}
