using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToState : State
{

    HearComponent hearComponent;
    SearchPhaseComponent searchPhaseComponent;
    protected override void InitTransitions()
    {
        Debug.Log("init GOtO");
        searchPhaseComponent = owner.GetComponent<SearchPhaseComponent>();
        MoveComponent _move = owner.GetComponent<MoveComponent>();
        hearComponent = owner.GetComponent<HearComponent>();

        if(hearComponent.HearSound)
        {
            searchPhaseComponent.SetLastPosition(hearComponent.LastSoundPos);
            searchPhaseComponent.ResetPhases();
        }
        searchPhaseComponent.InscreasePhase();
        searchPhaseComponent.SetTargetMoveTo();
        GoToPositionToSearchTransition _transi = new GoToPositionToSearchTransition(owner);
        SearchToChaseTransition _chaseTransi = new SearchToChaseTransition(owner);
        transitions.Add(_chaseTransi);
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

    public override void Update()
    {
        base.Update();
        CheckSound();
    }


    void CheckSound()
    {
        if (!hearComponent)
            return;
        if(hearComponent.HearSound)
        {
            searchPhaseComponent.SetLastPosition(hearComponent.LastSoundPos);
            searchPhaseComponent.ResetPhases();
            searchPhaseComponent.InscreasePhase();
            searchPhaseComponent.SetTargetMoveTo();
        }
    }
}
