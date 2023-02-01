using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition
{
    protected FSM owner = null;

    public Transition(FSM _owner)
    {
        owner = _owner;
    }

    public abstract bool IsTransitionValid { get; }

    public abstract void CallNext();
}
