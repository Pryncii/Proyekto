using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legattack : MonoBehaviour
{
    public int damage = 35;
    public float speed;
    public GameObject effect;
    public Animator camAnim;
    public int health = 100;


    // Start is called before the first frame update
    void Start()
    {
        
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

        if (health == 50)
        {
           transform.Translate(Vector2.right * speed * Time.deltaTime * 1.25f);
        }
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
            speed = 5;
            transform.localScale = new Vector3(-0.3f, 0.3f, 2f);
            health = 50;
           
        }
    }

}
