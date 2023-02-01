using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPositionToSearchTransition : Transition
{
    MoveComponent move = null;

    public override bool IsTransitionValid => move.IsAtDestination;

    public override void CallNext()
    {

        Debug.Log("CallNext");
        owner.SetNext<SearchState>();
    }

    public GoToPositionToSearchTransition(FSM _owner) : base(_owner)
    {
        move = _owner.GetComponent<MoveComponent>();
    }
}
