using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseToGoToTransition : Transition
{

    SightComponent sight = null;

    public override bool IsTransitionValid => !sight.PlayerInSight;

    public override void CallNext()
    {
        owner.SetNext<GoToState>();
    }

    public ChaseToGoToTransition(FSM _owner) : base(_owner)
    {
        sight = ((IARemi)_owner).Sight;
    }

}
