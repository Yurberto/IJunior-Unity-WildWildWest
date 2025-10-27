using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInputReader : IInitializable, IDisposable
{
    private PlayerInput _playerInput = new PlayerInput();

    Vector2 _moveDirection;
    Vector2 _lookDirection;

    public event Action<Vector3> MoveDirectionUpdated;
    public event Action<Vector3> LookDirectionUpdated;
    public event Action Jumped;

    public void Initialize()
    {
        _playerInput.Enable();

        _playerInput.Player.Move.performed += OnMove;
        _playerInput.Player.Look.performed += OnLook;
        _playerInput.Player.Jump.performed += OnJump;

        _playerInput.Player.Shoot.performed += OnShoot;
    }

    public void Dispose()
    {
        _playerInput.Disable();

        _playerInput.Player.Move.performed -= OnMove;
        _playerInput.Player.Look.performed -= OnLook;
        _playerInput.Player.Jump.performed -= OnJump;

        _playerInput.Player.Shoot.performed -= OnShoot;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.action.ReadValue<Vector2>();

        MoveDirectionUpdated?.Invoke(new Vector3(_moveDirection.x, 0.0f, _moveDirection.y));

        Debug.Log("Moved: " + _moveDirection.ToString());
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Jumped?.Invoke();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        _lookDirection = context.action.ReadValue<Vector2>();

        LookDirectionUpdated?.Invoke(new Vector2(-_lookDirection.y, _lookDirection.x));
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot");
    }
}
