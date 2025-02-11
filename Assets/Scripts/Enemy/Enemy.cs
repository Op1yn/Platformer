using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyMover _enemyMover;

    private void Update()
    {
        _enemyMover.Move();
    }
}
