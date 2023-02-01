using UnityEngine;

public class SearchState : State
{
    protected override void InitTransitions()
    {
        SearchToChaseTransition _searchToChase = new SearchToChaseTransition(owner);
        transitions.Add(_searchToChase);

        SearchToGoToTransition _searchToGoTo = new SearchToGoToTransition(owner);
        transitions.Add(_searchToGoTo);
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
