using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundingController _groundingController;
    [SerializeField] private PlayerMover _playerMover;

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _playerMover.TurnFront(_inputReader.Direction);
            _playerMover.Move(_inputReader.Direction);
        }


        if (_inputReader.GetIsJump() && _groundingController.IsGround)
            _playerMover.Jump();
    }
}
