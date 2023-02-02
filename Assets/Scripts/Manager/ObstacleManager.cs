using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : SingletonTemplate<ObstacleManager>
{
    [SerializeField] LayerMask obstacleMask;


    List<Obstacle> obstacles = new List<Obstacle>();
    public List<Obstacle> Obstacles => obstacles;

    public LayerMask ObstacleMask => obstacleMask;

    public void RegisterObstacle(Obstacle _obs)
    {
        obstacles.Add(_obs);
    }

    public void UnregisterObstacle(Obstacle _obs)
    {
        obstacles.Remove(_obs);
    }

    public bool IsLocationInObstacle(Vector3 _pos)
    {
        if (obstacles == null || obstacles.Count == 0)
            return false;

        Mesh _mesh = null;
        float _minBoundsX = 0f, _maxBoundsX = 0f, _minBoundsZ = 0f, _maxBoundsZ = 0f;
        for(int i = 0; i < obstacles.Count; i++)
        {
            if (!obstacles[i])
                continue;

            _mesh = obstacles[i].Mesh;

            if (_mesh == null)
                continue;

            _minBoundsX = _mesh.bounds.min.x;
            _maxBoundsX = _mesh.bounds.max.x; 
            _minBoundsZ = _mesh.bounds.min.z; 
            _maxBoundsZ = _mesh.bounds.max.z;

            if (IsValueInRange(_pos.x, _minBoundsX, _maxBoundsX) || IsValueInRange(_pos.z, _minBoundsZ, _maxBoundsZ))
                return true;
        }

        return false;
    }

    bool IsValueInRange(float _value, float _min, float _max) => _value >= _min && _value <= _max;
}
