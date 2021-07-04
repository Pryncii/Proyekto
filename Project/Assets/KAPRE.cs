using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAPRE : MonoBehaviour
{

    private Transform target;
    public float speed;
    public int health = 1000;
    public GameObject effect;
    public GameObject scoring;
    private float wait;
    public float startattack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatsenemy;
    public Animator kapreanim;
    public Animator camAnim;
    public int damage;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("despawn").GetComponent<Transform>();
        scoring = FindObjectOfType<ScoreManager>().gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 13)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (health <= 300)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f, 1);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            if (scoring != null)
            {
                scoring.gameObject.GetComponent<ScoreManager>().score += 100;
            }
        }

        if (wait > 0)
        {
            wait -= Time.deltaTime;

        }

        if (wait <= 0)
        {



            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsenemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {

                kapreanim.SetTrigger("SMASHU");

                StartCoroutine(Timedelay());



            }
            wait = startattack;
        }

      
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("KAP"))
        {
            Destroy(spawner);
        }

        if (other.CompareTag("Legg"))
        {
            health -= 200;
            Instantiate(effect, transform.position, Quaternion.identity);

        }


    }

    public void takedamage(int damage)
    {
        health -= damage;
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(0.5f);

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsenemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)

        {
            enemiesToDamage[i].GetComponent<Player>().health -= damage;

            GetComponent<AudioSource>().Play();

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");

        }

    }
}
