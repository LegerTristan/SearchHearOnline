using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchToChaseTransition : Transition
{
    SightComponent sightComp = null;

    public SearchToChaseTransition(FSM _owner) : base(_owner)
    {
        sightComp = owner.GetComponent<SightComponent>();
        Debug.Log($"SightComp : {sightComp.name}");
    }

    public override bool IsTransitionValid
    {
        get
        {
            Debug.Log($"SightComp : {sightComp.PlayerInSight}");
            return sightComp ? sightComp.PlayerInSight : false;
        }
    }

    public override void CallNext() => owner.SetNext<ChaseState>();
}
