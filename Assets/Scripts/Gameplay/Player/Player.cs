using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    private PlayerInputReader _inputReader;

    private Vector3 _currentMoveDirection = Vector3.zero;
    private Vector2 _currentMouseDelta = Vector3.zero;

    [Inject]
    private void Construct(PlayerInputReader playerInputReader)
    {
        _inputReader = playerInputReader;
    }

    private void OnEnable()
    {
        _inputReader.MoveDirectionUpdated += OnMove;
        _inputReader.LookDirectionUpdated += OnLook;

        _inputReader.Jumped += Jump;
    }

    private void OnDisable()
    {
        _inputReader.MoveDirectionUpdated -= OnMove;
        _inputReader.LookDirectionUpdated -= OnLook;

        _inputReader.Jumped -= Jump;
    }

    private void Update()
    {
        if (_currentMoveDirection == Vector3.zero)
        {
            _playerMover.StopMove();
        }
        else
        {
            _playerMover.Move(_currentMoveDirection);
            _playerMover.LookAt(_currentMoveDirection);
        }
    }

    private void OnLook(Vector2 mouseDelta)
    {
        _currentMouseDelta = mouseDelta;
    }

    private void OnMove(Vector3 direction)
    {
        _currentMoveDirection = direction;
    }

    private void Jump()
    {
        _playerMover.Jump();
    }
}
