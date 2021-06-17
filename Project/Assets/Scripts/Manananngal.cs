using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manananngal : MonoBehaviour
{

    public Animator anim;
    public GameObject Leg;
    private Vector2 targetPos;
    public float speed;
    public float Yincrement;
    public GameObject effect;
    public Transform shotPoint;
    public int damage = 20;
    public Animator camAnim;
    public int health = 100;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
        Instantiate(effect, transform.position, Quaternion.identity);
        targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);

        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);

        anim.SetBool("Attack", true);
        Instantiate(Leg, shotPoint.position, transform.rotation);
        transform.localScale = new Vector3(0.27f, 0.27f, 2f);

        StartCoroutine(Idle());



    }

    IEnumerator Idle()

    {
        yield return new WaitForSeconds(0.45f);
        anim.SetBool("Idle", true);
        
        transform.localScale = new Vector3(0.25f, 0.25f, 2f);
        targetPos = new Vector2(transform.position.x - 30, transform.position.y);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");

        }


        if (other.CompareTag("leg"))
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("despawn"))
        {
            Destroy(gameObject);
        }
    }
}
