using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : IInputService
{
    private PlayerInput _playerInput = new PlayerInput();

    public event Action JumpPressed;

    public event Action ShootPressed;
    public event Action ShootReleased;

    public event Action GetMainWeaponPressed;
    public event Action GetNextWeaponPressed;
    public event Action PutAwayWeaponPressed;

    public event Action<Vector2> MouseDeltaUpdated;

    public Vector3 MoveDirection { get; private set; }

    public void Initialize()
    {
        _playerInput.Enable();

        _playerInput.Player.Look.performed += OnLook;

        _playerInput.Player.Move.performed += OnMoveButtonPressed;
        _playerInput.Player.Move.canceled += OnMoveButtonReleased;

        _playerInput.Player.Jump.performed += OnJumpClicked;

        _playerInput.Player.Shoot.performed += OnShootButtonPressed;
        _playerInput.Player.Shoot.canceled += OnShootButtonReleased;

        _playerInput.Player.GetMainWeapon.performed += OnGetMainWeapon;
        _playerInput.Player.GetNextWeapon.performed += OnGetNextWeapon;
        _playerInput.Player.PutAwayWeapon.performed += OnPutAwayWeapon;
    }

    public void Dispose()
    {
        _playerInput.Disable();

        _playerInput.Player.Look.performed -= OnLook;

        _playerInput.Player.Move.performed -= OnMoveButtonPressed;
        _playerInput.Player.Move.canceled -= OnMoveButtonReleased;

        _playerInput.Player.Jump.performed -= OnJumpClicked;

        _playerInput.Player.Shoot.performed -= OnShootButtonPressed;
        _playerInput.Player.Shoot.canceled -= OnShootButtonReleased;

        _playerInput.Player.GetMainWeapon.performed -= OnGetMainWeapon;
        _playerInput.Player.GetNextWeapon.performed -= OnGetNextWeapon;
        _playerInput.Player.PutAwayWeapon.performed -= OnPutAwayWeapon;
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

    private void OnShootButtonPressed(InputAction.CallbackContext context) =>
        ShootPressed?.Invoke();

    private void OnShootButtonReleased(InputAction.CallbackContext context) =>
        ShootReleased?.Invoke();

    private void OnMoveButtonReleased(InputAction.CallbackContext context) =>
        MoveDirection = Vector3.zero;

    private void OnJumpClicked(InputAction.CallbackContext context) =>
        JumpPressed?.Invoke();

    private void OnGetMainWeapon(InputAction.CallbackContext context) =>
        GetMainWeaponPressed?.Invoke();

    private void OnGetNextWeapon(InputAction.CallbackContext context) =>
        GetNextWeaponPressed?.Invoke();

    private void OnPutAwayWeapon(InputAction.CallbackContext context) => 
        PutAwayWeaponPressed?.Invoke(); 
}
