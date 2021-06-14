
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour

{ 
    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startPlayerPosition, endPlayerPosition;
    private float movetime;
    public LayerMask whatsenemy;
    public float attackRange;
    public Transform attackPos;
    private float wait;
    public float startattack;
    private Vector2 targetPos;
    public float Yincrement;
    public float maxheight;
    public float minheight;
    public float speed;
    public int health = 100;
    public Animator target;
    public int damage;
    public Animator camAnim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }


        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (wait > 0)
        {
            wait -= Time.deltaTime;

        }

        if (wait <= 0)
        {


            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsenemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {



                    StartCoroutine(Timedelay());
                    StartCoroutine(Bull());




                }
                wait = startattack;

            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            

            if ((endTouchPosition.y < startTouchPosition.y) && transform.position.y > minheight)
            {
               
                targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);

                target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();

                target.SetBool("Moving", true);

            }

            if ((endTouchPosition.y > startTouchPosition.y) && transform.position.y < maxheight)

            {
               
                targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);

                target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();

                target.SetBool("Moving", true);

            }

            


        }

        

        

       

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(0.01f);

        
            
       Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsenemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)

        {


            enemiesToDamage[i].GetComponent<Kiwig>().health -= damage;

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");


        }



    }

    IEnumerator Bull()
    {
        yield return new WaitForSeconds(0.01f);



        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsenemy);
        for (int a = 0; a < enemiesToDamage.Length; a++)

        {


            enemiesToDamage[a].GetComponent<AttackSarangay>().health -= damage;

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");


        }

    }






    }
