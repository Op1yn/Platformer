using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyMover _enemyMover;

    private void FixedUpdate()
    {
        _enemyMover.Move();
    }
}
