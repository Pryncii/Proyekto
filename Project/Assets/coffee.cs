using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffee : MonoBehaviour
{
    public Animator anim;
    private Vector2 targetPos;
    public float speed;
    public Animator camAnim;
    public GameObject Player;
    public float wait;
    public float startattack;
    public GameObject jumpy;
    public GameObject barky;
    public GameObject scoring;
    public GameObject effect;
    private Transform target;
    public float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector2(transform.position.x, transform.position.y);
        transform.position = targetPos;
        Player = FindObjectOfType<Player>().gameObject;
        startattack = PlayerPrefs.GetInt("StartAttack", 3);
        target = GameObject.FindGameObjectWithTag("Playz").GetComponent<Transform>();
        scoring = FindObjectOfType<ScoreManager>().gameObject;
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }

           
       

       
       

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.1f);

        
        anim.SetTrigger("Attack");
        target = GameObject.FindGameObjectWithTag("Here").GetComponent<Transform>();

       
        StartCoroutine(Go());

    }

    IEnumerator Go()

    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(effect, transform.position, Quaternion.identity);
        anim.SetTrigger("Attack");
        StartCoroutine(Idle());

    }

    IEnumerator Idle()

    {
        yield return new WaitForSeconds(0.6f);
        target = GameObject.FindGameObjectWithTag("Playz").GetComponent<Transform>();
        transform.localScale = new Vector3(-0.3f, 0.3f, 1f);
        

    }

     public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Legspawn"))
        {
            Destroy(gameObject);
        }
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

    public void woof()
    {
        if (wait <= 0)
        {
            if (gameObject.activeSelf == true)
            {
                StartCoroutine(Attack());
                wait = startattack;
                Instantiate(barky, transform.position, Quaternion.identity);
               
            }
        }
    }

    public void Specialwoof()
    {
        
            if (gameObject.activeSelf == true)
            {
            Instantiate(effect, transform.position, Quaternion.identity);
            StartCoroutine(Attack());
               
                Instantiate(barky, transform.position, Quaternion.identity);
                transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
            }
       
    }

    public void woofy()
    {
      
            if (gameObject.activeSelf == true)
            {
                StartCoroutine(Attack());
               
                Instantiate(barky, transform.position, Quaternion.identity);
            }
        
    }

}
