using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSightComponent : MonoBehaviour
{
    [SerializeField]
    LayerMask targetLayer, obstacleLayer;

    [SerializeField]
    int range = 5, sightAngle = 45;

    bool detection = false;

    void Update() => UpdateSight();

    void UpdateSight()
    {
        Vector3 _pos = transform.position;

        Collider[]  _colliders = Physics.OverlapSphere(transform.position, range, targetLayer);
        detection = false;
        if (_colliders == null || _colliders.Length == 0)
            return;

        for(int i = 0; i < _colliders.Length; ++i)
        {
            Collider _collider = _colliders[i];

            if (!_collider)
                continue;

            Vector3 _dir = ( _collider.transform.position - _pos).normalized;
            float _angle = GetAngleFromVectors(transform.forward, _dir);

            if(_angle < sightAngle)
            {
                float _dist = Vector3.Distance(_pos, _collider.transform.position);
                detection = !Physics.Raycast(_pos, _dir, _dist, obstacleLayer);
            }
            else
                detection = false;
        }
    }

    int GetAngleFromVectors(Vector3 _a, Vector3 _b)
    {
        float _size = Mathf.Sqrt(_a.sqrMagnitude * _b.sqrMagnitude);
        return Mathf.CeilToInt(Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(_a, _b) / _size));
    }

    void OnDrawGizmos()
    {
        Vector3 _pos = transform.position;

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(_pos, _pos + Quaternion.AngleAxis(sightAngle, transform.up) * transform.forward * range);
        Gizmos.DrawLine(_pos, _pos + Quaternion.AngleAxis(-sightAngle, transform.up) * transform.forward * range);

        Gizmos.color = detection ? Color.green : Color.red;
        //Gizmos.DrawWireSphere(transform.position, range);

        DrawCircle();
    }

    void DrawCircle()
    {
        Vector3[] _points = new Vector3[sightAngle * 2];

        for(int i = 0; i < _points.Length; ++i)
        {
            _points[i] = transform.position + GetPointFromAngle(i - sightAngle, range);
            Gizmos.DrawLine(_points[i], transform.position +  GetPointFromAngle(i+1 - sightAngle, range));
        }
    }

    Vector3 GetPointFromAngle(int _angle, int _radius)
    {
        _angle += 90;
        float _rad = Mathf.Deg2Rad * _angle;

        float _x = Mathf.Cos(_rad) * _radius,
              _z = Mathf.Sin(_rad) * _radius;

        return transform.right * _x + transform.forward * _z;
    }
}
