using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _route;
    [SerializeField] private float _speed;

    public event Action<Vector2> PointChanged;
    private Vector2[] _positionRoutePoints;
    private int _currentPoint = 0;

    void Start()
    {
        _positionRoutePoints = new Vector2[_route.childCount];

        for (int i = 0; i < _route.childCount; i++)
            _positionRoutePoints[i] = _route.GetChild(i).transform.position;
    }

    public void Move()
    {
        if (HasPointReached())
        {
            SwitchRoutePoint();
        }

        transform.position = Vector2.MoveTowards(transform.position, _positionRoutePoints[_currentPoint], _speed * Time.deltaTime);
    }

    private bool HasPointReached()
    {
        float pointDistanceReach = 0.2f;
        Vector2 offset = _positionRoutePoints[_currentPoint] - new Vector2(transform.position.x, transform.position.y);

        return offset.sqrMagnitude <= pointDistanceReach;
    }

    private void SwitchRoutePoint()
    {
        _currentPoint = (_currentPoint + 1) % _positionRoutePoints.Length;

        PointChanged?.Invoke(_positionRoutePoints[_currentPoint]);
    }    
}