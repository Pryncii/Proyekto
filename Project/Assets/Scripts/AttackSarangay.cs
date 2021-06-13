using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSarangay : MonoBehaviour
{
    public int damage = 50;
    public float speed;
    public Animator camAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
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
