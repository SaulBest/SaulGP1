using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM2 : MonoBehaviour
{



    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;


    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;



    // Update is called once per frame
    void Update()

    {


        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }

        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }



            if (patrolDestination == 8)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[8].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[8].position) < .2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 9;

                }
            }


            if (patrolDestination == 9)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[9].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[9].position) < .2f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 8;

                }
            }
        }






    }
}