using UnityEngine;

public class EnemyFlipper : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;

    private void OnEnable()
    {
        _enemyMover.PointChanged += TurnFront;
    }

    private void OnDisable()
    {
        _enemyMover.PointChanged -= TurnFront;
    }

    private void TurnFront(Vector2 pointPosition)
    {
        int reversDirection = 180;

        if (transform.position.x < pointPosition.x)
        {
            _enemyMover.transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        }
        else
        {
            _enemyMover.transform.rotation = Quaternion.Euler(new Vector2(0, reversDirection));
        }
    }
}
