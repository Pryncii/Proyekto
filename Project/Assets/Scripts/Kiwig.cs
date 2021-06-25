using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwig : MonoBehaviour
{
    public int damage = 25;
    public float speed;
    public GameObject effect;
    public Animator camAnim;
    public int health = 200;
    private float dazetime;
    public float startdazetime;
    public Animator kiki;
    public GameObject scoring;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        
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




        if (dazetime <= 0)
        {
            speed = 7;
            kiki.SetBool("Hurt", false);
            transform.localScale = new Vector3(0.2f, 0.2f, 2f);
        } else
        {
            speed = 0;
            dazetime -= Time.deltaTime;
            kiki.SetBool("Hurt", true);
            transform.localScale = new Vector3(0.25f, 0.25f, 2f);
        }

       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);

           camAnim  = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");
            GetComponent<AudioSource>().Play();

        }

        if (other.CompareTag("despawn"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Legg"))
        {
            health = 0;
            Instantiate(effect, transform.position, Quaternion.identity);
            

        }
    }

    public void amage(int damage)
    {
        dazetime = startdazetime;
        health -= damage;
        Instantiate(effect, transform.position, Quaternion.identity);

    }
}
