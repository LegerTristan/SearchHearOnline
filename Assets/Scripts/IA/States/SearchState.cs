using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
    protected override void InitTransitions()
    {
    }

    public override void DebugState()
    {
        Transform _ownerTransform = owner.transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_ownerTransform.position + _ownerTransform.up, .1f);
    }

    public override void Exit()
    {
    }
}
