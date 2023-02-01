using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    MoveComponent move = null;
    Player player = null;
    SearchPhaseComponent searchPhase = null;

    protected override void InitTransitions()
    {
         player = PlayerManager.Instance?.GetPlayer;
         move = owner.GetComponent<MoveComponent>();
        searchPhase = owner.GetComponent<SearchPhaseComponent>();
        searchPhase.ResetPhases();
        move.SetTarget(player.transform.position);
        ChaseToGoToTransition _transi = new ChaseToGoToTransition(owner);
        transitions.Add(_transi);
    }

    public override void DebugState()
    {
        Transform _ownerTransform = owner.transform;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_ownerTransform.position + _ownerTransform.up, .1f);
    }

    public override void Update()
    {
        base.Update();
        if (!move || !player)
            return;
        move.SetTarget(player.transform.position);
    }

    public override void Exit()
    {
        searchPhase.SetLastPosition(player.transform.position);
        searchPhase = null;
        move = null;
        player = null;
    }
}
