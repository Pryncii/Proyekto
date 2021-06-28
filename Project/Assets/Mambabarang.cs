using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mambabarang : MonoBehaviour
{
    public int damage = 10;
    public GameObject effect;
    public int health = 100;
    public float speed;
    public Animator anim;
    public Animator camAnim;
    private Vector2 targetPos;
    public GameObject[] obstaclePatterns;
    private float timebtwspawn;
    public float starttimebtwspawn;
    public float decreasetime;
    public float minTime;
    private float wait;
    public AudioSource Ready;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Idle());
        anim.SetBool("Attack", true);
        speed = 0;
        wait = 0.5f;
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {



        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);


        }

        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if ((timebtwspawn <= 0) && (wait <= 0.5f))
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timebtwspawn = starttimebtwspawn;

            if (starttimebtwspawn > minTime)
            {
                starttimebtwspawn -= decreasetime;
            }
        }
        else
        {
            timebtwspawn -= Time.deltaTime;
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2f);

        anim.SetBool("Attack", true);
        speed = 0;

        StartCoroutine(Idle());



    }

    IEnumerator Idle()

    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Attack", false);
        StartCoroutine(Attack());
        speed = 2f;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");
            Ready.Play();

        }

        if (other.CompareTag("Legg"))
        {
            health = 0;
            Instantiate(effect, transform.position, Quaternion.identity);


        }
    }


}