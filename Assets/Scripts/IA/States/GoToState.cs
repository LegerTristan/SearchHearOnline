using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToState : State
{

    protected override void InitTransitions()
    {
        Debug.Log("init GOtO");
        SearchPhaseComponent _search = owner.GetComponent<SearchPhaseComponent>();
        _search.InscreasePhase();
        _search.SetTargetMoveTo();
        GoToPositionToSearchTransition _transi = new GoToPositionToSearchTransition(owner);
        transitions.Add(_transi);
    }
    
    public override void DebugState()
    {
        Transform _ownerTransform = owner.transform;

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(_ownerTransform.position + _ownerTransform.up, .1f);
    }

    public override void Exit()
    {

    }
}
