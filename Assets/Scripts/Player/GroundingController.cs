using System;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GroundingController : MonoBehaviour
{
    public event Action<bool> IsGroundChanged;
    public bool IsGround { get; private set; }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            TurnIsGround(true);

        //Debug.Log($"IsGround111 {IsGround}");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            TurnIsGround(false);

        //Debug.Log($"IsGround222 {IsGround}");
    }

    private void TurnIsGround(bool value)
    {
        IsGround = value;

        IsGroundChanged?.Invoke(value);
    }
}
