using UnityEngine;

public class SearchToGoToTransition : Transition
{
    float waitTime = 15f, currentTime = 0f;

    public SearchToGoToTransition(FSM _owner) : base(_owner)
    {

    }

    public override bool IsTransitionValid
    {
        get
        {
            currentTime += Time.deltaTime;
            return currentTime >= waitTime;
        }
    }

    public override void CallNext() => owner.SetNext<GoToState>();
}
