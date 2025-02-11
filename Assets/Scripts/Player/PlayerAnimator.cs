using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundingDetector;

    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));

    private void OnEnable()
    {
        _groundingDetector.IsGroundChanged += TurnIsJumping;
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(Speed, Mathf.Abs(_inputReader.Direction));
    }

    private void OnDisable()
    {
        _groundingDetector.IsGroundChanged -= TurnIsJumping;
    }

    private void TurnIsJumping(bool value)
    {
        _animator.SetBool(IsJumping, !value);
    }
}
