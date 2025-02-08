using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(_speedX * direction * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
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
