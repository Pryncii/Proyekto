using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Decoy : MonoBehaviour

{
    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startPlayerPosition, endPlayerPosition;
    private float movetime;
    public GameObject Player;
    private Vector2 targetPos;
    public float Yincrement;
    public float maxheight;
    public float minheight;
    public float speed;
   
    public int health = 100;


    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector2(transform.position.x, transform.position.y + 0.2f);
        transform.position = targetPos;
        Player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {


        Player Total = Player.GetComponent<Player>();


        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxheight && Player.activeSelf == true)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minheight && Player.activeSelf == true)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos;
        }


        
        


    }


    public void moveup()
    {
        if (transform.position.y < maxheight && Player.activeSelf == true)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;

        }
    }

    public void movedown()
    {
        if (transform.position.y > minheight && Player.activeSelf == true)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos;
        }

    }


}
