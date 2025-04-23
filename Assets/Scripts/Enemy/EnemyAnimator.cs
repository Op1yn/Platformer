using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    public event Action StruckWith;
    public event Action AttackAnimationEnded;

    public void ReportAttack()
    {
        StruckWith?.Invoke();
    }

    public void FinishAttack()
    {
        _animator.SetBool(IsAttack, false);
        AttackAnimationEnded?.Invoke();
    }

    public void StartAttackAnimation()
    {
        _animator.SetBool(IsAttack, true);
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool(IsAttack, false);
    }
}