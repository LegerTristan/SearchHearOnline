using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveComponent : MonoBehaviour
{
    //public event Action<bool> OnPlayerAtDestination;

    Vector3 target = Vector3.zero;
    int speed = 0;
    bool asATarget = false;
    bool isAtDestination = false;

    public bool IsAtDestination => isAtDestination;

    private void Update()
    {
        MoveTo();
    }


    public void SetTarget(Vector3 _target, int _speed)
    {
        speed = _speed;
        target = _target;
        isAtDestination = false;
        asATarget = true;
    }

    void MoveTo()
    {
        if (!asATarget)
            return;
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if(Vector3.Distance(transform.position,target) < 0.1)
        {
            isAtDestination = true;
            asATarget=false;
        }
    }


}
