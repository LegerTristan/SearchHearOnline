using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IARemi : FSM
{
    [SerializeField] SightComponent sight = null;
    public SightComponent Sight => sight;

    protected override void InitFSM()
    {
       SetNext<GoToState>();
        Debug.Log("InitFSM");
    }

    protected override void StopFSM()
    {

    }



}
