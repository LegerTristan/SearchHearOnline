using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : SingletonTemplate<ObstacleManager>
{
    [SerializeField] LayerMask obstacleMask;


    List<Obstacle> obstacles;
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


}
