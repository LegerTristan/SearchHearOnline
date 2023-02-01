using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        ObstacleManager.Instance?.RegisterObstacle(this);
    }

    private void OnDestroy()
    {
        ObstacleManager.Instance?.UnregisterObstacle(this);
    }

}
