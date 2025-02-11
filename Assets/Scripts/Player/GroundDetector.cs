using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public event Action<bool> IsGroundChanged;
    public bool IsGround { get; private set; }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            TurnIsGround(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            TurnIsGround(false);
    }

    private void TurnIsGround(bool value)
    {
        IsGround = value;

        IsGroundChanged?.Invoke(value);
    }
}
