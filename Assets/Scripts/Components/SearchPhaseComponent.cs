using System.Collections.Generic;
using UnityEngine;

public class SearchPhaseComponent : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List<Phase> allPhases;
    int currentPhase = -1;

    Vector3 test;

    Vector3 lastPlayerPosition = Vector3.zero;
    bool isFirstTime = true;

    private void Update()
    {
 
    }

    public void InscreasePhase()
    {
        currentPhase++;
        currentPhase = currentPhase >= allPhases.Count ? 0 : currentPhase;
    }

    public void DecreasePhase()
    {
        currentPhase--;
        currentPhase = currentPhase < 0 ? 0 : currentPhase;
    }

    public void ResetPhases()
    {
        currentPhase = 0;
    }

    public void SetLastPosition(Vector3 _pos)
    {
        lastPlayerPosition = _pos;
    }

    public void SetTargetMoveTo()
    {
       MoveComponent _move = GetComponent<MoveComponent>();
        _move.SetTarget(GetPosition(), allPhases[currentPhase].Speed);
    }

    public Vector3 GetPosition()
    {
        if (isFirstTime)
        {
            isFirstTime = false;
            lastPlayerPosition = player.position;
        }
        return GenerateRandomPointInCircle();
    }

    Vector3 GenerateRandomPointInCircle()
    {

        float _angle = Random.Range(0, 360);
        Debug.Log(_angle);
        float _x = Mathf.Cos(_angle * Mathf.Deg2Rad) * allPhases[currentPhase].Radius;
        float _y = Mathf.Sin(_angle * Mathf.Deg2Rad) * allPhases[currentPhase].Radius;
        test = lastPlayerPosition + new Vector3(_x, 0, _y);
        Debug.Log(test);
        return lastPlayerPosition + new Vector3(_x, 0, _y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(test, player.position);
        int _seg = 360 / 100;
        if (currentPhase == -1)
            return;
        for (int i = 0; i < 360; i += _seg)
        {
            
            float _x = Mathf.Cos(i * Mathf.Deg2Rad) * allPhases[currentPhase].Radius;
            float _y = Mathf.Sin(i * Mathf.Deg2Rad) * allPhases[currentPhase].Radius;
            float _x2 = Mathf.Cos((i+_seg) * Mathf.Deg2Rad) * allPhases[currentPhase].Radius;
            float _y2 = Mathf.Sin((i+_seg) * Mathf.Deg2Rad) * allPhases[currentPhase].Radius;
            Vector3 _draw = lastPlayerPosition + new Vector3(_x, 0, _y);
            Vector3 _draw2 = lastPlayerPosition + new Vector3(_x2, 0, _y2);
            Gizmos.DrawLine(_draw, _draw2);
        }
    }


}
