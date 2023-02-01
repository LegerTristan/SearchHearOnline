using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IATristan : FSM
{
    protected override void InitFSM()
    {
        SetNext<SearchState>();
    }

    protected override void StopFSM()
    {
       
    }
}
