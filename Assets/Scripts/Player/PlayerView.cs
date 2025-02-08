using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundingController _groundingController;

    private void OnEnable()
    {
        _groundingController.IsGroundChanged += TurnIsJumping;
    }

    private void OnDisable()
    {
        _groundingController.IsGroundChanged -= TurnIsJumping;
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_inputReader.Direction));
    }    

    private void TurnIsJumping(bool value)
    {
        _animator.SetBool("isJumping", !value);
    }
}
