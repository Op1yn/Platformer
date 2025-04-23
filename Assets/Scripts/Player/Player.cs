using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundingDetector;
    [SerializeField] private PlayerMover _playerMover;

    private void FixedUpdate()
    {
        if (_playerMover.IsPossibleMove)
        {
            if (_inputReader.Direction != 0)
            {
                _playerMover.TurnFront(_inputReader.Direction);
                _playerMover.Move(_inputReader.Direction);
            }

            if (_playerMover.WasJumpPressed && _groundingDetector.IsGround)
            {
                _playerMover.Jump();
            }
        }
    }
}