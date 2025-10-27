using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerInputReader : MonoBehaviour
{
    private PlayerInput _playerInput = new PlayerInput();

    Vector2 _moveDirection;
    Vector2 _lookDirection;

    public event Action<Vector3> MoveDirectionUpdated;
    public event Action<Vector3> ViewDirectionUpdated;

    private void OnEnable()
    {
        _playerInput.Enable();

        _playerInput.Player.Move.performed += OnMove;
        _playerInput.Player.Look.performed += OnLook;

        _playerInput.Player.Shoot.performed += OnShoot;
    }

    private void OnDisable()
    {
        _playerInput.Disable();

        _playerInput.Player.Move.performed -= OnMove;
        _playerInput.Player.Look.performed -= OnLook;

        _playerInput.Player.Shoot.performed -= OnShoot;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.action.ReadValue<Vector2>();

        MoveDirectionUpdated?.Invoke(new Vector3(_moveDirection.x, 0.0f, _moveDirection.y));

        Debug.Log("Moved: " + _moveDirection.ToString());
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        _lookDirection = context.action.ReadValue<Vector2>();

        ViewDirectionUpdated?.Invoke(new Vector3(-_moveDirection.y, _moveDirection.x, 0.0f));
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot");
    }
}
