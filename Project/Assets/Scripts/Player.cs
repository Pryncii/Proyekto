
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;



public class Player : MonoBehaviour

{


    public Text healthdisplay;
    public Text cooldowndisplay;
    public Text cooldownspecial;
    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startPlayerPosition, endPlayerPosition;
    private float movetime;
    public LayerMask kiwig;
    public LayerMask sarangay;
    public LayerMask tiktik;
    public LayerMask Manananggal;
    public LayerMask leg;
    public LayerMask Mambabarang;
    public LayerMask Kapre;
    public float attackRange;
    public Transform attackPos;
    private float wait;
    public float startattack;
    private float Specialwait;
    public float startspecial;
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
    public GameObject jumpy;
    public GameObject effect;
    public GameObject eff;
    public GameObject GO;
    public AudioSource Ready;
    public AudioSource Attack;
    public AudioSource Hit;
    public AudioSource jump;
    public AudioSource special;
    public GameObject scoring;
    public GameObject windblade;
    public GameObject ButtonControl;
    public Transform shotPoint;

#if UNITY_IOS
    private string gameId = "4190594";
#elif UNITY_ANDROID
    private string gameId = "4190595";
#endif

    bool testMode = true;



    // Start is called before the first frame update
    void Start()
    {
        // position the player
        targetPos = new Vector2(transform.position.x, transform.position.y + 0.2f);
          // Initialize the Ads service:
        Advertisement.Initialize(gameId, testMode);
        scoring = FindObjectOfType<ScoreManager>().gameObject;
        health = PlayerPrefs.GetInt("Health", 100);
        damage = PlayerPrefs.GetInt("Damage", 100);
        startattack = PlayerPrefs.GetInt("StartAttack", 3);
       startspecial = PlayerPrefs.GetInt("StartSpecial", 25);

    }

    // Update is called once per frame
    void Update()
    {
        // UI inputs
        healthdisplay.text = health.ToString();
        cooldowndisplay.text = wait.ToString("0");
        cooldownspecial.text = Specialwait.ToString("0");

        // Player death
        if (health <= 0)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
                // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
            }
            GO.SetActive(true);
            Destroy(gameObject);
            Instantiate(eff, transform.position, Quaternion.identity);
            scoring.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            ScoreManager Total = scoring.GetComponent<ScoreManager>();
            
            PlayerPrefs.SetInt("TotalScore", Total.Totalscored += Total.score);
        }

        // PC Move up

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxheight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(jumpy, transform.position, Quaternion.identity);

        }

        // PC Move down
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minheight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos;
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(jumpy, transform.position, Quaternion.identity);

        }
        // PC Special Attack 
        if (Specialwait > 0)
        {
            Specialwait -= Time.deltaTime;

        }
        if (Specialwait >= 0.01 && Specialwait <= 0.06)
        {
            special.Play();
        }

        if (Specialwait <= 0)
        {
            cooldownspecial.text = ("Ready");

            if (Input.GetKeyDown(KeyCode.RightArrow) && windblade.activeSelf == true)
            {
               
                Instantiate(windblade, shotPoint.position, transform.rotation);
                Specialwait = startspecial;
              
                Attack.Play();

            }


        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (wait > 0)
        {
            wait -= Time.deltaTime;

        }

        if (wait > 0.01 && wait < 0.025)
        {
            Ready.Play();
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        if (wait <= 0)
        {
            cooldowndisplay.text = ("Ready");

         
                if (Input.GetKeyDown(KeyCode.Space))
            {

                Attack.Play();

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

                Collider2D[] MamDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Mambabarang);
                for (int a = 0; a < MamDamage.Length; a++)
                {
                    StartCoroutine(Mam());
                    
                }

                Collider2D[] KapDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Kapre);
                for (int a = 0; a < KapDamage.Length; a++)
                {
                    StartCoroutine(Kap());

                }

                wait = startattack;

            }
        }
       
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            

            if ((endTouchPosition.y < startTouchPosition.y) && transform.position.y > minheight && ButtonControl.activeSelf == false)
            {
               
                targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
                Instantiate(jumpy, transform.position, Quaternion.identity);
                transform.position = targetPos;
                Instantiate(effect, transform.position, Quaternion.identity);



            }

            if ((endTouchPosition.y > startTouchPosition.y) && transform.position.y < maxheight && ButtonControl.activeSelf == false)

            {
               
                targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
                Instantiate(jumpy, transform.position, Quaternion.identity);
                transform.position = targetPos;
                Instantiate(effect, transform.position, Quaternion.identity);



            }

            if (wait <= 0)
            {


                if ((endTouchPosition.x >= startTouchPosition.x) && (endTouchPosition.y == startTouchPosition.y) && ButtonControl.activeSelf == false)
                {

                    Attack.Play();

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

                    Collider2D[] MamDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Mambabarang);
                    for (int a = 0; a < MamDamage.Length; a++)
                    {
                        StartCoroutine(Mam());
                    }

                    Collider2D[] KapDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Kapre);
                    for (int a = 0; a < KapDamage.Length; a++)
                    {
                        StartCoroutine(Kap());

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

            Attack.Play();

            Hit.Play();

            scoring.gameObject.GetComponent<ScoreManager>().score += 1;

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

            Attack.Play();
            Hit.Play();
            scoring.gameObject.GetComponent<ScoreManager>().score += 3;

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

            Attack.Play();
            Hit.Play();
            scoring.gameObject.GetComponent<ScoreManager>().score += 1;

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

            Attack.Play();
            Hit.Play();
            scoring.gameObject.GetComponent<ScoreManager>().score += 2;

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
            Hit.Play();
            Attack.Play();
            scoring.gameObject.GetComponent<ScoreManager>().score += 3;


        }

    }

    IEnumerator Mam()
    {
        yield return new WaitForSeconds(0.01f);



        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Mambabarang);
        for (int t = 0; t < enemiesToDamage.Length; t++)

        {


            enemiesToDamage[t].GetComponent<Mambabarang>().health -= damage;

            scoring.gameObject.GetComponent<ScoreManager>().score += 2;

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");

            Attack.Play();
            Hit.Play();

        }

    }

    IEnumerator Kap()
    {
        yield return new WaitForSeconds(0.01f);



        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Kapre);
        for (int t = 0; t < enemiesToDamage.Length; t++)

        {


            enemiesToDamage[t].GetComponent<KAPRE>().takedamage(damage);

            scoring.gameObject.GetComponent<ScoreManager>().score += 5;

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");

            Attack.Play();
            Hit.Play();

        }

    }

    public void moveup()
    {
        if (transform.position.y < maxheight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(jumpy, transform.position, Quaternion.identity);

        }
    }

    public void movedown()
    {

        if (transform.position.y > minheight)
        {

            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            Instantiate(jumpy, transform.position, Quaternion.identity);
            transform.position = targetPos;
            Instantiate(effect, transform.position, Quaternion.identity);

        }
    }

    public void att()
    {
        Attack.Play();

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

        Collider2D[] MamDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Mambabarang);
        for (int a = 0; a < MamDamage.Length; a++)
        {
            StartCoroutine(Mam());
        }

        Collider2D[] KapDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Kapre);
        for (int a = 0; a < KapDamage.Length; a++)
        {
            StartCoroutine(Kap());

        }


        wait = startattack;
    }

    public void Special()
    {
        if (Specialwait <= 0 && windblade.activeSelf == true)
        {

         
                Instantiate(windblade, shotPoint.position, transform.rotation);
                Specialwait = startspecial;

                Attack.Play();

        }
    }

    public void HealthUpOne()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 3000)
        {
            PlayerPrefs.SetInt("Health", 125);

           
        }
    }

    public void HealthDownOne()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 3000)
        {
            PlayerPrefs.SetInt("Health", 100);
        }
    }


    public void DamageUpOne()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 5000)
        {
            PlayerPrefs.SetInt("Damage", 200);
        }
    }

    public void DamageDownOne()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 5000)
        {
            PlayerPrefs.SetInt("Damage", 100);
        }
    }

    public void SpeedUpOne()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 10000)
        {
            PlayerPrefs.SetInt("StartAttack", 2);
        }
    }

    public void SpeedDownOne()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 10000)
        {
            PlayerPrefs.SetInt("StartAttack", 3);
        }
    }

    public void SpecialUpOne()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 15000)
        {
            PlayerPrefs.SetInt("StartSpecial", 20);
        }
    }

    public void SpecialDownOne()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 15000)
        {
            PlayerPrefs.SetInt("StartSpecial", 25);
        }
    }

    public void HealthUpTwo()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 20000)
        {
            PlayerPrefs.SetInt("Health", 150);
        }
    }


    public void HealthDownTwo()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 20000)
        {
            PlayerPrefs.SetInt("Health", 100);
        }
    }



}
