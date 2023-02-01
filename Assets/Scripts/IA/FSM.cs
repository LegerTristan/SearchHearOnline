using UnityEngine;

public abstract class FSM : MonoBehaviour
{
    protected State currentState = null;

    void Start() => InitFSM();

    void Update() => UpdateFSM();

    void OnDestroy() => StopFSM();

    void OnDrawGizmos() => currentState?.DebugState();

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
