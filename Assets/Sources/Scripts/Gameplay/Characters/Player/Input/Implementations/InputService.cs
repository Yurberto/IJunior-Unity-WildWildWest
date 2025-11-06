using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputService : IInputService, IInitializable, IDisposable
{
    private PlayerInput _playerInput = new PlayerInput();

    public event Action JumpButtonPressed;

    public event Action ShootPressed;
    public event Action ShootReleased;

    public Vector3 MoveDirection { get; private set; }

    public void Initialize()
    {
        Debug.Log("InputService Init");
        _playerInput.Enable();

        _playerInput.Player.Jump.performed += OnJumpClicked;

        _playerInput.Player.Move.performed += OnMoveButtonPressed;
        _playerInput.Player.Move.canceled += OnMoveButtonReleased;
    }

    public void Dispose()
    {
        Debug.Log("InputService Dispose");
        _playerInput.Disable();

        _playerInput.Player.Jump.performed -= OnJumpClicked;

        _playerInput.Player.Move.performed -= OnMoveButtonPressed;
        _playerInput.Player.Move.canceled -= OnMoveButtonReleased;
    }

    private void OnJumpClicked(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        JumpButtonPressed?.Invoke();
    }

    private void OnMoveButtonPressed(InputAction.CallbackContext context)
    {
        Vector2 direction2D = context.ReadValue<Vector2>();
        Debug.Log(direction2D);
        MoveDirection = new Vector3 (direction2D.x, 0.0f, direction2D.y);
    }

    private void OnMoveButtonReleased(InputAction.CallbackContext context)
    {
        Debug.Log("Stop");
        MoveDirection = Vector3.zero;
    }
}
