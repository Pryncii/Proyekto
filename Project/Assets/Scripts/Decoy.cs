using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Decoy : MonoBehaviour

{
    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startPlayerPosition, endPlayerPosition;
    private float movetime;

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
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxheight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
           
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minheight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;



            if ((endTouchPosition.y < startTouchPosition.y) && transform.position.y > minheight)
            {

                targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
                transform.position = targetPos;



            }

            if ((endTouchPosition.y > startTouchPosition.y) && transform.position.y < maxheight)

            {

                targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
                transform.position = targetPos;
            }

            if ((endTouchPosition.x > startTouchPosition.x) && transform.position.y < maxheight)
            {

            }


        }


    }


}
