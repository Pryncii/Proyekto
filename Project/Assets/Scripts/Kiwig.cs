using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwig : MonoBehaviour
{
    public int damage = 25;
    public float speed;
    public GameObject effect;
    public Animator camAnim;
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);

           camAnim  = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

            camAnim.SetTrigger("shake");

        }

        if (other.CompareTag("despawn"))
        {
            Destroy(gameObject);
        }
    }
}
