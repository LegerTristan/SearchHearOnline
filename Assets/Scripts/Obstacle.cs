using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Obstacle : MonoBehaviour
{
    MeshFilter meshFilter = null;

    public Mesh Mesh => meshFilter ? meshFilter.mesh : null;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        meshFilter = GetComponent<MeshFilter>();
        Debug.Log(meshFilter);
        Debug.Log(ObstacleManager.Instance);
        Debug.Log(this);
        ObstacleManager.Instance?.RegisterObstacle(this);
    }

    private void OnDestroy()
    {
        ObstacleManager.Instance?.UnregisterObstacle(this);
    }

}
