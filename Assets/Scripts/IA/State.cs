using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected FSM owner = null;

    protected List<Transition> transitions = new List<Transition>();

    public virtual void Enter(FSM _owner)
    {
        owner = _owner;
        InitTransitions();
    }

    protected abstract void InitTransitions();

    void CheckTransitions()
    {
        for(int i  = 0; i < transitions.Count; ++i)
        {
            if (transitions[i].IsTransitionValid)
                transitions[i].CallNext();
        }
    }

    public virtual void Update()
    {
        CheckTransitions();
    }

    public abstract void Exit();

    public abstract void DebugState();
}
