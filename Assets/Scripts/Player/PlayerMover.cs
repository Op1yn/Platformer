using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private bool _wasJumpPressed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.JumpBeenPressed += SetIsJump;
    }

    private void OnDisable()
    {
        _inputReader.JumpBeenPressed -= SetIsJump;
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(_speedX * direction * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        if (_wasJumpPressed)
        {
            _wasJumpPressed = false;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    public void SetIsJump()
    {
        _wasJumpPressed = true;
    }

    public void TurnFront(float direction)
    {
        if (Mathf.Abs(direction) > 0)
        {
            int reversDirection = 180;
            float directionNormalized = Mathf.Sign(direction);

            if (directionNormalized < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector2(0, directionNormalized) * reversDirection);
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector2(0, directionNormalized));
            }
        }
    }
}
