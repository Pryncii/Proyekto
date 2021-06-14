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
    private float speed = 0;
    public Animator camAnim;
    public int health = 100;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
        
      
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
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);

        anim.SetBool("Attack", true);

        speed = 17;
        


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

        if (other.CompareTag("despawn"))
        {
            Destroy(gameObject);
        }


    }

}
