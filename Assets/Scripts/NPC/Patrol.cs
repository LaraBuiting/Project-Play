using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    //public float leftWayPoint;
    //public float middleWayPoint;
    //public float rightWayPoint;

    public Animator anim;

    public Transform[] moveSpots;
    private int randomSpot;
    private int currentSpot = 1;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        Vector3 walkDir = transform.position - moveSpots[randomSpot].position;
        walkDir.Normalize();
        if(walkDir.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            anim.SetBool("Walking", true);

            if (randomSpot == 0 && currentSpot == 1)
            {
                //GetComponent<SpriteRenderer>().flipX = false;
                currentSpot = 0;
            }

            //    else if (randomSpot == 1 && currentSpot == 0)
            //    {
            //        //GetComponent<SpriteRenderer>().flipX = true;
            //        currentSpot = 1;
            //    }

            //    else if (randomSpot == 1 && currentSpot == 2)
            //    {
            //        //GetComponent<SpriteRenderer>().flipX = false;
            //        currentSpot = 1;
            //    }

            //    else if (randomSpot == 2 && currentSpot == 1)
            //    {
            //        //GetComponent<SpriteRenderer>().flipX = true;
            //        currentSpot = 2;
            //    }

            if (waitTime <= 0)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            waitTime = startWaitTime;
        }
        else
        {
            anim.SetBool("Walking", false);
            waitTime -= Time.deltaTime;
        }
        }
    }
}
