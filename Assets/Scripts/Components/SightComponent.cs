using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SightComponent : MonoBehaviour
{
    public event Action<bool> OnDetectPlayer = null;

    [SerializeField]
    LayerMask playerLayer = new LayerMask(), obstacleLayer = new LayerMask();

    WaitForSeconds waitRefresh = null;

    [SerializeField, Range(0.01f, 5f)]
    float viewRefreshRate = 1f;

    [SerializeField, Range(0.1f, 100f)]
    float viewRange = 5f;

    [SerializeField]
    float oscillation = 0f;

    [SerializeField, Range(0, 180)]
    int viewAngle = 90;

    [SerializeField]
    bool oscillate = true, isOscillationIncreasing = true;

    void Start()
    {
        waitRefresh = new WaitForSeconds(viewRefreshRate);
        //StartCoroutine(Sight());
    }

    //IEnumerator Sight()
    //{
    //    ExecuteSight();
    //    yield return waitRefresh;

    //    StartCoroutine(Sight());
    //}

    void Update() => ExecuteSight();

    void ExecuteSight()
    {
        UpdateOscillation();

        RaycastHit _hitPlayer, _hitObstacle;
        Color _debugColor = Color.white;
        float _range = 1f;
        for (int i = 0; i < viewAngle; ++i)
        {
            float _angle = (i - (viewAngle / 2f)) * Mathf.Deg2Rad;
            float _x = Mathf.Cos(_angle),
                  _y = Mathf.Sin(oscillation),
                  _z = Mathf.Sin(_angle);

            Vector3 _point = _x * transform.right + _y * transform.up + _z * transform.forward;

            bool _playerInSight = Physics.Raycast(transform.position, _point, out _hitPlayer, viewRange, playerLayer);
            bool _obstacleInSight = Physics.Raycast(transform.position, _point, out _hitObstacle, viewRange, obstacleLayer);


            if (!PlayerDetection(_playerInSight, _obstacleInSight, _hitPlayer, _hitObstacle, ref _debugColor,
                ref _range))
                ObstacleDetection(_obstacleInSight, _hitObstacle, ref _debugColor, ref _range);

            Debug.DrawRay(transform.position, _point * _range, _debugColor);
        }
    }

    void UpdateOscillation()
    {
        if (!oscillate)
            return;
        oscillation += isOscillationIncreasing ? Time.deltaTime : -Time.deltaTime;
        oscillation = oscillation > 1f ? 1f : oscillation;
        oscillation = oscillation < -1f ? -1f : oscillation;

        if (isOscillationIncreasing)
            isOscillationIncreasing = oscillation <= 1.0f;
        else
            isOscillationIncreasing = oscillation <= -1.0f;
    }

    bool PlayerDetection(bool _playerInSight, bool _obstacleInSight, RaycastHit _hitPlayer, RaycastHit _hitObstacle, 
        ref Color _debugColor, ref float _range)
    {
        if(_playerInSight)
        {
            _debugColor = _obstacleInSight ? Color.yellow : Color.green;
            _range = _obstacleInSight ? _hitObstacle.distance : _hitPlayer.distance;
        }
        //else
        //{
        //    _debugColor = _obstacleInSight ? Color.green : Color.red;
        //    _range = _obstacleInSight ? _hitPlayer.distance : viewRange;
        //}

        return _playerInSight;
    }

    void ObstacleDetection(bool _obstacleInSight, RaycastHit _hitObstacle, ref Color _debugColor, ref float _range)
    {
        _debugColor = _obstacleInSight ? Color.blue : Color.red;
        _range = _obstacleInSight ? _hitObstacle.distance : viewRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
