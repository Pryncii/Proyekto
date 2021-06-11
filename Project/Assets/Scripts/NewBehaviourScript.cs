using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startPlayerPosition, endPlayerPosition;
    private float movetime;
    private float moveduration = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if ((endTouchPosition.y < startTouchPosition.y) && transform.position.y > -3f)
                StartCoroutine(Move("down"));

            if ((endTouchPosition.y > startTouchPosition.y) && transform.position.y < 3f)
                StartCoroutine(Move("up"));




        }
    }

    private IEnumerator Move(string wheretoMove)
    {
        switch (wheretoMove)
        {
            case "down":
                movetime = 0f;
                startPlayerPosition = transform.position;
                endPlayerPosition = new Vector3
                    (startPlayerPosition.y - 3f, transform.position.x, transform.position.z);

                while (movetime < moveduration)
                {
                    movetime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (startPlayerPosition, endPlayerPosition, movetime / moveduration);
                    yield return null;
                }
                break;

            case "up":
                movetime = 0f;
                startPlayerPosition = transform.position;
                endPlayerPosition = new Vector3
                    (startPlayerPosition.y + 3f, transform.position.x, transform.position.z);

                while (movetime < moveduration)
                {
                    movetime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (startPlayerPosition, endPlayerPosition, movetime / moveduration);
                    yield return null;
                }
                break;
        }
    }
}
