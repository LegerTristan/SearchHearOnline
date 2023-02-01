using UnityEngine;

public abstract class FSM : MonoBehaviour
{
    protected State currentState = null;

    protected abstract void InitFSM();

    protected virtual void UpdateFSM()
    {
        currentState?.Update();
    }

    protected abstract void StopFSM();

    public void SetNext<TState>() where TState : State, new()
    {
        currentState?.Exit();
        currentState = new TState();
        currentState?.Enter(this);
    }
}
