using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] obstaclePatterns;
    private float timebtwspawn;
    public float starttimebtwspawn;
        public float decreasetime;
    public float minTime;
    private float wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }

        if ((timebtwspawn <= 0) && (wait <= 0))
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timebtwspawn = starttimebtwspawn;

                if(starttimebtwspawn > minTime)
            {
                starttimebtwspawn -= decreasetime;
            }
        }
        else
        {
            timebtwspawn -= Time.deltaTime;
        }
    }
}
