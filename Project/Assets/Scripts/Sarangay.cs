using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarangay : MonoBehaviour
{

    public int duration;
    public GameObject charge;
    private float wait;
    public GameObject effect;
    public int damage = 50;
    public float speed = 0;
    public Animator camAnim;
    public int health = 100;
    public Animator anim;
    private float dazetime;
    public float startdazetime;
    private Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
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
            
            StartCoroutine(Attack());
            anim.SetBool("Dizzy", false);
            targetPos = new Vector2(transform.position.x, transform.position.y - 0.5f);


        }
        else
        {
          
            dazetime -= Time.deltaTime;
            anim.SetBool("Dizzy", true);
            anim.SetBool("Attack", false);
            targetPos = new Vector2(transform.position.x, transform.position.y + 0.5f);

        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);

        anim.SetBool("Attack", true);

        damage = 50;


        if (dazetime <= 0)
        {
            speed = 15;
            anim.SetBool("Dizzy", false);
            
        }
        else
        {
            speed = 0;
            damage = 0;
            anim.SetBool("Dizzy", true);
           

        }

    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            GetComponent<AudioSource>().Play();
            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");
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

    public void hurt(int damage)
    {
        dazetime = startdazetime;
        health -= damage;
        Instantiate(effect, transform.position, Quaternion.identity);
        targetPos = new Vector2(transform.position.x, transform.position.y + 1f);

    }



}
