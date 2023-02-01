using UnityEngine;

public class SearchToGoToTransition : Transition
{
    HearComponent hearComp = null;

    float waitTime = 15f, currentTime = 0f;

    public SearchToGoToTransition(FSM _owner) : base(_owner)
    {
        hearComp = owner.GetComponent<HearComponent>();
    }

    public override bool IsTransitionValid
    {
        get
        {
            currentTime += Time.deltaTime;
            return hearComp ? hearComp.HearSound || currentTime >= waitTime : currentTime >= waitTime;
        }
    }

    public override void CallNext() => owner.SetNext<GoToState>();
}
