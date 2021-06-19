
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Player : MonoBehaviour

{
    public Text healthdisplay;
    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startPlayerPosition, endPlayerPosition;
    private float movetime;
    public LayerMask kiwig;
    public LayerMask sarangay;
    public LayerMask tiktik;
    public LayerMask Manananggal;
    public LayerMask leg;
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
    public GameObject unit;
    public GameObject effect;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        healthdisplay.text = health.ToString();

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }


      

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxheight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minheight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos;
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (wait > 0)
        {
            wait -= Time.deltaTime;

        }

        if (wait <= 0)
        {


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, kiwig);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {

                    StartCoroutine(Timedelay());


                }

                Collider2D[] ToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, sarangay);
                for (int a = 0; a < ToDamage.Length; a++)
                {
                    StartCoroutine(Bull());
                }

                Collider2D[] TikDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, tiktik);
                for (int a = 0; a < TikDamage.Length; a++)
                {
                    StartCoroutine(Tik());
                }

                Collider2D[] ManaDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Manananggal);
                for (int a = 0; a < ManaDamage.Length; a++)
                {
                    StartCoroutine(Bik());
                }


                Collider2D[] legDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, leg);
                for (int a = 0; a < legDamage.Length; a++)
                {
                    StartCoroutine(Leg());
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
  

            }

            if ((endTouchPosition.y > startTouchPosition.y) && transform.position.y < maxheight)

            {
               
                targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);

    
            }

            if (wait <= 0)
            {


                if ((endTouchPosition.x >= startTouchPosition.x) && (endTouchPosition.y == startTouchPosition.y))
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, kiwig);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {



                        StartCoroutine(Timedelay());





                    }

                    Collider2D[] ToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, sarangay);
                    for (int a = 0; a < ToDamage.Length; a++)
                    {
                        StartCoroutine(Bull());
                    }

                    Collider2D[] TikDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, tiktik);
                    for (int a = 0; a < TikDamage.Length; a++)
                    {
                        StartCoroutine(Tik());
                    }

                    Collider2D[] ManaDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Manananggal);
                    for (int a = 0; a < ManaDamage.Length; a++)
                    {
                        StartCoroutine(Bik());
                    }


                    Collider2D[] legDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, leg);
                    for (int a = 0; a < legDamage.Length; a++)
                    {
                        StartCoroutine(Leg());
                    }



                    wait = startattack;

                }
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

        
            
       Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, kiwig);
        for (int i = 0; i < enemiesToDamage.Length; i++)

        {
            

            enemiesToDamage[i].GetComponent<Kiwig>().amage(damage);

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");
            

        }



    }

    IEnumerator Bull()
    {
        yield return new WaitForSeconds(0.01f);



        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, sarangay);
        for (int a = 0; a < enemiesToDamage.Length; a++)

        {


            enemiesToDamage[a].GetComponent<Sarangay>().hurt(damage);

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");


        }

    }

    IEnumerator Tik()
    {
        yield return new WaitForSeconds(0.01f);



        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, tiktik);
        for (int t = 0; t < enemiesToDamage.Length; t++)

        {


            enemiesToDamage[t].GetComponent<Tiktik>().health -= damage;

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");


        }

    }

    IEnumerator Bik()
    {
        yield return new WaitForSeconds(0.01f);



        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Manananggal);
        for (int t = 0; t < enemiesToDamage.Length; t++)

        {


            enemiesToDamage[t].GetComponent<Manananngal>().health -= damage;

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");


        }

    }

    IEnumerator Leg()
    {
        yield return new WaitForSeconds(0.01f);



        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, leg);
        for (int t = 0; t < enemiesToDamage.Length; t++)

        {


            enemiesToDamage[t].GetComponent<Legattack>().takedamage(damage);

            

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");


        }

    }






}
