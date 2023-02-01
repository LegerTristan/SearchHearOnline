using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected FSM owner = null;

    public abstract void Enter(FSM _owner);

    public abstract void CheckTransitions();

    public abstract void Update();

    public abstract void Exit();

    public abstract void DebugState();
}
