using UnityEngine;

public class EnemyStateAttack : EnemyState
{
    //� ��������� ����� ������� ������� ��� ������� ��� https://t.me/KaDR_gamedev/176

    private int _damage = 25;
    //private PlayerHealthManager _healthManager;

    //private bool _isAttacking = false;
    //private float _timeLastStrike = 0;
    //private float _delayBetweenAttacks = 2f;

    public EnemyStateAttack(EnemyStateMachine stateMachine, EnemyFlipper enemyFlipper, EnemyPersecutionDetector enemyPersecutionManager, EnemyAttackDetector enemyAttackDetector, EnemyAnimator enemyAnimator) : base(stateMachine, enemyFlipper, enemyPersecutionManager, enemyAttackDetector, enemyAnimator)
    {
        _enemyAnimator.StruckWith += TryInflictDamage;
        _enemyAnimator.AttackAnimationEnded += TrySwitchToPersecutionState;
    }

    public override void Enter(Transform T)
    {
        SetTarget(T);
        _enemyAnimator.StartAttackAnimation();
    }

    public override void Update()
    {
        //��� ������� ������ ���, � ����� ������ �� ������ ��� ��� ����� � ������ Enter ���������� ����� ������ �����. � ����� ����� ������� �������, ������ �� ��. �������� ��� ����������
    }

    public override void Exit()
    {
        Debug.Log("����� �� �����");
    }

    private void TryInflictDamage()
    {
        if (_enemyAttackDetector.TryGetPlayerHealthManager(out PlayerHealthManager playerHealthManager))
        {
            playerHealthManager.TakeDamage(_damage);
        }
    }

    public void TrySwitchToPersecutionState()
    {
        _enemyStateMachine.SetState<EnemyStatePersecution>(Target);
    }
}
