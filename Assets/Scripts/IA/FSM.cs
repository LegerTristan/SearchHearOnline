using UnityEngine;
using System.Collections;

public abstract class FSM : MonoBehaviour
{
    protected State currentState = null;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        InitFSM();
    }

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
