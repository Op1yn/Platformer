using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _route;
    [SerializeField] private float _speed;

    private Vector2[] _routePoints;
    private int _currentPoint = 0;
    private bool _IsAllowedToMove = true;

    public event Action<Vector2> PointChanged;

    private void Start()
    {
        _routePoints = new Vector2[_route.childCount];

        for (int i = 0; i < _route.childCount; i++)
            _routePoints[i] = _route.GetChild(i).transform.position;
    }

    public void Move()
    {
        if (HasPointReached())
        {
            SwitchRoutePoint();
        }

        if (_IsAllowedToMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, _routePoints[_currentPoint], _speed * Time.deltaTime);
        }
    }

    public void StopToAttack()
    {
        _IsAllowedToMove = false;
    }

    public void AllowMovement()
    {
        _IsAllowedToMove = true;
    }

    private bool HasPointReached()
    {
        float pointDistanceReach = 0.2f;
        Vector2 offset = _routePoints[_currentPoint] - new Vector2(transform.position.x, transform.position.y);

        return offset.sqrMagnitude <= pointDistanceReach;
    }

    private void SwitchRoutePoint()
    {
        _currentPoint = (_currentPoint + 1) % _routePoints.Length;

        PointChanged?.Invoke(_routePoints[_currentPoint]);
    }
}