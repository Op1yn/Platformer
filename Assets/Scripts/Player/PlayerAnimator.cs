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
        _groundingDetector.LeavingOffGround += SetIsJumpingOffGround;
        _groundingDetector.Landed += SetIsJumpingLanding;
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(Speed, Mathf.Abs(_inputReader.Direction));
    }

    private void OnDisable()
    {
        _groundingDetector.LeavingOffGround -= SetIsJumpingOffGround;
        _groundingDetector.Landed -= SetIsJumpingLanding;
    }

    private void SetIsJumpingLanding()
    {
        _animator.SetBool(IsJumping, false);
    }

    private void SetIsJumpingOffGround()
    {
        _animator.SetBool(IsJumping, true);
    }
}
