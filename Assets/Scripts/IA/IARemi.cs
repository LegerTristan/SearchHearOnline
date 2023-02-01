using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IARemi : FSM
{


    protected override void InitFSM()
    {
       SetNext<GoToState>();
        Debug.Log("InitFSM");
    }

    protected override void StopFSM()
    {

    }



}
