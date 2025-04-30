using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class UnitInRaceMoving : MonoBehaviour
{
    internal bool ismoving { get; private set; } = false;
    private float passDistance = 0.01f;
    private float speed = 1f;

    private Vector3 target;

    void Update()
    {
        if (ismoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed );

            if (Vector3.Distance(transform.position, target) <= passDistance)
            {
                ismoving = false;
            }
        }
    }

    public void StartRace(Vector3 moveTo)
    {
        target = moveTo;
        ismoving = true;

        transform.LookAt( target );
    }
    public void StartRace(Vector3 moveTo, float _speed)
    {
        target = moveTo;
        speed = _speed;
        ismoving = true;
        transform.LookAt(target);
    }


}
