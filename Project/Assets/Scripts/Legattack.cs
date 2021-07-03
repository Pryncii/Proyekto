using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legattack : MonoBehaviour
{
    public int damage = 35;
    public float speed;
    public GameObject effect;
    public Animator camAnim;
    public int health = 300;
    public float lifetime;
    public GameObject scoring;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
        scoring = FindObjectOfType<ScoreManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);

        }

        if (health == 50)
        {
           transform.Translate(Vector2.right * speed * Time.deltaTime * 1.2f);
            transform.localScale = new Vector3(-0.27f, 0.27f, 2f);

        }

        if (health == 100)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime * 3f);
            transform.localScale = new Vector3(-0.27f, 0.27f, 2f);

        }

        if (health == 200)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime * 3f);
            transform.localScale = new Vector3(-0.27f, 0.27f, 2f);

        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");

            GetComponent<AudioSource>().Play();

        }

        if (other.CompareTag("Enemy") && CompareTag("Legg"))

        {
            scoring.gameObject.GetComponent<ScoreManager>().score += 1;

            GetComponent<AudioSource>().Play();
            
        }

        if (other.CompareTag("Legg"))
        {
            health = 0;

            Instantiate(effect, transform.position, Quaternion.identity);
        }


        if (other.CompareTag("despawn"))
        {
           
            transform.localScale = new Vector3(-0.27f, 0.27f, 2f);
            health = 50;
            damage = 20;

           
        }
    }

    public void takedamage(int damage)
    {
        health -= damage;
        gameObject.tag = "Legg";
    }

  

}
