using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiktik : MonoBehaviour
{

    public float speed;
    public float movement;
    public float startmove;
    private Transform target;
    public float minheight;
    private float wait;
    public float startattack;
    public GameObject effect;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatsenemy;
    public int damage;
    public int health = 100;
    public Animator tiktikanim;
    public Animator camAnim;
    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startPlayerPosition, endPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Playe").GetComponent<Transform>();
            Instantiate(effect, transform.position, Quaternion.identity);
        tiktikanim.SetBool("Moving", true);
    }

    // Update is called once per frame
    void Update()
    {
        
        
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


        if (Input.GetKey(KeyCode.UpArrow))
        {
            tiktikanim.SetBool("Moving", true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            tiktikanim.SetBool("Moving", true);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);

        }



        if (wait > 0)
        {
            wait -= Time.deltaTime;
           
        }

        if (wait <= 0)
        {



            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsenemy);
            for (int i = 0; i <enemiesToDamage.Length; i++)
            {
                
                tiktikanim.SetTrigger("Tiktikswipe");

                StartCoroutine(Timedelay());
                    
                

            }
            wait = startattack;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;



            if ((endTouchPosition.y < startTouchPosition.y))
            {

                tiktikanim.SetBool("Moving", true);




            }

            if ((endTouchPosition.y > startTouchPosition.y))

            {

                tiktikanim.SetBool("Moving", true);




            }





        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Playe"))
        {
            tiktikanim.SetBool("Moving", false);
        }

        if (other.CompareTag("Legg"))
        {
            health = 0;
            Instantiate(effect, transform.position, Quaternion.identity);
           
        }


    }

    IEnumerator Timedelay()
    { 
      yield return new WaitForSeconds(0.3f);

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
