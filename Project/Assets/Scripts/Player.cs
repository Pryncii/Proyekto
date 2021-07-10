
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.EventSystems;



public class Player : MonoBehaviour, IUnityAdsListener

{

    public GameObject SpecialButton;
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
    public LayerMask Swarme;
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
    public AudioSource super;
    public GameObject scoring;
    public GameObject windblade;
    public GameObject Lavaspread;
    public GameObject Waterjet;
    public GameObject ShadowBarrier;
    public GameObject ButtonControl;
    public Transform shotPoint;

    string mySurfacingId = "rewardedVideo";

#if UNITY_IOS
    private string gameId = "4190594";
#elif UNITY_ANDROID
    private string gameId = "4190595";
#endif

    bool testMode = true;



    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1;
        Advertisement.AddListener(this);
        // position the player
        targetPos = new Vector2(transform.position.x, transform.position.y + 0.2f);
          // Initialize the Ads service:
        Advertisement.Initialize(gameId, testMode);
        scoring = FindObjectOfType<ScoreManager>().gameObject;
        health = PlayerPrefs.GetInt("Health", 100);
        damage = PlayerPrefs.GetInt("Damage", 100);
        startattack = PlayerPrefs.GetInt("StartAttack", 3);
       startspecial = PlayerPrefs.GetInt("StartSpecial", 25);
        PlayerPrefs.GetInt("Special", 0);
        
        windblade.gameObject.SetActive(PlayerPrefs.GetInt("Special") == 1);
        Lavaspread.gameObject.SetActive(PlayerPrefs.GetInt("Special") == 2);
        Waterjet.gameObject.SetActive(PlayerPrefs.GetInt("Special") == 3);
        ShadowBarrier.gameObject.SetActive(PlayerPrefs.GetInt("Special") == 4);

    }

    // Update is called once per frame
    void Update()
    {

        if (ShadowBarrier.activeSelf == true)
        {
            shotPoint.transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
        }
        if (Lavaspread.activeSelf == true)
        {
            shotPoint.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        }

        if (Waterjet.activeSelf == true)
        {
            shotPoint.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        }
        // UI inputs
        healthdisplay.text = health.ToString();
        cooldowndisplay.text = wait.ToString("0");
        cooldownspecial.text = Specialwait.ToString("0");

        // Player death

        if (health <= 0)
        {


            ShowInterstitialAd();
            GO.SetActive(true);
            gameObject.SetActive(false);
            Instantiate(eff, transform.position, Quaternion.identity);
            scoring.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Time.timeScale = 0;
            
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
            SpecialButton.SetActive(false);

        }
        if (Specialwait >= 0.01 && Specialwait <= 0.06)
        {
            special.Play();
        }

        if (Specialwait <= 0)
        {
            cooldownspecial.text = ("Ready");
            SpecialButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.RightArrow) && windblade.activeSelf == true)
            {
               
                Instantiate(windblade, shotPoint.position, transform.rotation);
                Specialwait = startspecial;

                super.Play();

            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && ShadowBarrier.activeSelf == true)
            {

                Instantiate(ShadowBarrier, shotPoint.position, transform.rotation);
                Specialwait = startspecial;

                super.Play();

            }
          

                if (Input.GetKeyDown(KeyCode.RightArrow) && Lavaspread.activeSelf == true)
            {

                Instantiate(Lavaspread, shotPoint.position, transform.rotation);
                Specialwait = startspecial;

                super.Play();

            }
            

            if (Input.GetKeyDown(KeyCode.RightArrow) && Waterjet.activeSelf == true)
            {

                Instantiate(Waterjet, shotPoint.position, transform.rotation);
                Specialwait = startspecial;

                super.Play();

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

                Collider2D[] swarmDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Swarme);
                for (int a = 0; a < swarmDamage.Length; a++)
                {
                    StartCoroutine(Swarmy());

                }
                wait = startattack;

            }
        }




        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;

            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("Touch");
                startattack = 0;
                StartCoroutine(SpeedNormal());
            }
        }
            
        

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;


            if ((endTouchPosition.y < startTouchPosition.y) && transform.position.y > minheight)
            {
               
                targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
                Instantiate(jumpy, transform.position, Quaternion.identity);
                transform.position = targetPos;
                Instantiate(effect, transform.position, Quaternion.identity);



            }

            if ((endTouchPosition.y > startTouchPosition.y) && transform.position.y < maxheight)

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

                    Collider2D[] swarmDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Swarme);
                    for (int a = 0; a < swarmDamage.Length; a++)
                    {
                        StartCoroutine(Swarmy());

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


    IEnumerator Swarmy()
    {
        yield return new WaitForSeconds(0.01f);



        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Swarme);
        for (int t = 0; t < enemiesToDamage.Length; t++)

        {


            enemiesToDamage[t].GetComponent<swarm>().health -= damage;

            scoring.gameObject.GetComponent<ScoreManager>().score += 1;

            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");

            Attack.Play();
            Hit.Play();

        }

    }

    IEnumerator SpeedNormal()
    {
        yield return new WaitForSeconds(0.1f);

        if (PlayerPrefs.GetInt("StartAttack", 3) == 3)
        {
            startattack = 3;
        }

        if (PlayerPrefs.GetInt("StartAttack", 3) == 2) 
        {
            startattack = 2;
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

       




        if (Specialwait <= 0)
            {
                if (windblade.activeSelf == true)
                {
                    Instantiate(windblade, shotPoint.position, transform.rotation);
                    Specialwait = startspecial;

                    super.Play();
                }

                if (ShadowBarrier.activeSelf == true)
                {

                    Instantiate(ShadowBarrier, shotPoint.position, transform.rotation);
                    Specialwait = startspecial;

                    super.Play();

                }

                if (Lavaspread.activeSelf == true)
                {

                    Instantiate(Lavaspread, shotPoint.position, transform.rotation);
                    Specialwait = startspecial;

                    super.Play();

                }

                if (Waterjet.activeSelf == true)
                {

                    Instantiate(Waterjet, shotPoint.position, transform.rotation);
                    Specialwait = startspecial;

                    super.Play();

                }
            }
        

       


    }

    public void HealthUpOne()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 1000)
        {
            PlayerPrefs.SetInt("Health", 125);

           
        }
    }

    public void HealthDownOne()
    {
        if (PlayerPrefs.GetInt("TotalScore", 0) >= 1000)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f, 0.5f);
            Instantiate(eff, transform.position, Quaternion.identity);
            StartCoroutine(NormalToo());
        }

        if (other.CompareTag("leg"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f, 0.5f);
            Instantiate(eff, transform.position, Quaternion.identity);
            StartCoroutine(NormalToo());
        }
    }



    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
            // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (surfacingId == mySurfacingId)
            {
                // Reward the user for watching the ad to completion.
                GO.SetActive(false);
              
                gameObject.SetActive(true);
                health = 50;
                scoring.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                Instantiate(effect, transform.position, Quaternion.identity);
                StartCoroutine(Normal());
                Time.timeScale = 1;
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    IEnumerator Normal()
    {
        yield return new WaitForSeconds(3f);
       GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
       
    }

    IEnumerator NormalToo()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

    }

}
