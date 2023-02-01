using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveComponent : MonoBehaviour
{
    //public event Action<bool> OnPlayerAtDestination;

    [SerializeField] Animator animator;

    Vector3 target = Vector3.zero;
    int speed = 0;
    bool asATarget = false;
    bool isAtDestination = false;

    public bool IsAtDestination => isAtDestination;

    private void Update()
    {
        MoveTo();
        LookTo();
    }


    public void SetTarget(Vector3 _target, int _speed = 2)
    {
        speed = _speed;
        target = _target;
        isAtDestination = false;
        asATarget = true;
        animator.SetBool("iswalking", true);
    }

    void MoveTo()
    {
        if (!asATarget)
            return;
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if(Vector3.Distance(transform.position,target) < 0.1)
        {
            animator.SetBool("iswalking", false);
            isAtDestination = true;
            asATarget=false;
        }
    }

    void LookTo()
    {
        if (!asATarget)
            return;
        Vector3 _fwd = target - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_fwd);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,_rot, Time.deltaTime * 200);
    }


}
