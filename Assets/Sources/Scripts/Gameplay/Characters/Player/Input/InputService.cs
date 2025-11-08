using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : IInputService
{
    private PlayerInput _playerInput = new PlayerInput();

    public event Action JumpButtonPressed;

    public event Action ShootPressed;
    public event Action ShootReleased;

    public event Action<Vector2> MouseDeltaUpdated;

    public Vector3 MoveDirection { get; private set; }

    public void Initialize()
    {
        _playerInput.Enable();

        _playerInput.Player.Look.performed += OnLook;

        _playerInput.Player.Move.performed += OnMoveButtonPressed;
        _playerInput.Player.Move.canceled += OnMoveButtonReleased;

        _playerInput.Player.Jump.performed += OnJumpClicked;
    }

    public void Dispose()
    {
        _playerInput.Disable();

        _playerInput.Player.Look.performed -= OnLook;

        _playerInput.Player.Move.performed -= OnMoveButtonPressed;
        _playerInput.Player.Move.canceled -= OnMoveButtonReleased;

        _playerInput.Player.Jump.performed -= OnJumpClicked;
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        Vector2 offset = context.ReadValue<Vector2>();
        MouseDeltaUpdated?.Invoke(offset);
    }

    private void OnMoveButtonPressed(InputAction.CallbackContext context)
    {
        Vector2 direction2D = context.ReadValue<Vector2>();
        MoveDirection = new Vector3 (direction2D.x, 0.0f, direction2D.y);
    }

    private void OnMoveButtonReleased(InputAction.CallbackContext context)
    {
        MoveDirection = Vector3.zero;
    }

    private void OnJumpClicked(InputAction.CallbackContext context)
    {
        JumpButtonPressed?.Invoke();
    }
}
