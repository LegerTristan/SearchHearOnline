using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Obstacle : MonoBehaviour
{
    MeshFilter meshFilter = null;

    public MeshFilter MeshFilter => meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        meshFilter = GetComponent<MeshFilter>();
        ObstacleManager.Instance?.RegisterObstacle(this);
    }

    private void OnDestroy()
    {
        ObstacleManager.Instance?.UnregisterObstacle(this);
    }

}
