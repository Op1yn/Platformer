using UnityEngine;

public class EnemyStateMovement : EnemyState
{
    protected readonly Transform _transform;
    protected readonly float _speed;

    public EnemyStateMovement(EnemyStateMachine stateMachine, Transform transform, float speed, EnemyFlipper enemyFlipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator) : base(stateMachine, enemyFlipper, enemyPersecutionManager, enemyAttackDetector, enemyAnimator)
    {
        _transform = transform;
        _speed = speed;
    }

    public override void Enter(Transform T)
    {
        Debug.Log("ENTER");
    }

    public override void Update()
    {
        Debug.Log("UPDATE");
        Move();
    }

    public override void Exit()
    {
        Debug.Log("EXIT");
    }

    public virtual void Move()
    {
        if (Target == null)
        {
            Debug.Log("������ ������");
        }

        if (_transform == null)
        {
            Debug.Log("��������� ������");
        }

        Debug.Log($"��� ���� {Target.name}");

        _transform.position = Vector2.MoveTowards(_transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}