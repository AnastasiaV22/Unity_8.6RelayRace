using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
   // [SerializeField] GameObject obj;

    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;
    [SerializeField] GameObject point3;
    [SerializeField] GameObject point4;
    [SerializeField] GameObject point5;

    private Vector3[] path;
    private int currentTarget = 0;
    
    private bool direction = true;
    private bool isMoving = false;
    [SerializeField] private float speed = 1f;

    void Start()
    {
        path = new Vector3[5] { point1.transform.position, point2.transform.position, point3.transform.position, point4.transform.position, point5.transform.position};
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, path[currentTarget], Time.deltaTime * speed);
        }
        else
        {
            if (direction)
                currentTarget++;
            else currentTarget--;

            if (currentTarget == 0 || currentTarget == 4)
            {
                direction = !direction;
            }

            transform.LookAt(path[currentTarget]);

            isMoving = true;
        }

        if (transform.position == path[currentTarget])
        {
            isMoving = false;

        }
    }
}
