using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private CameraRotator _cameraRotator;

    private PlayerInputReader _inputReader;

    [Inject]
    private void Construct(PlayerInputReader playerInputReader)
    {
        _inputReader = playerInputReader;
    }

    private void OnEnable()
    {
        _inputReader.MoveDirectionUpdated += Move;
        _inputReader.LookDirectionUpdated += Rotate;

        _inputReader.Jumped += Jump;
    }

    private void OnDisable()
    {
        _inputReader.MoveDirectionUpdated -= Move;
        _inputReader.LookDirectionUpdated -= Rotate;

        _inputReader.Jumped -= Jump;
    }

    private void Move(Vector3 direction)
    {
        _playerMover.Move(direction);
        _playerMover.LookAt(direction);
    }

    private void Rotate(Vector3 offset)
    { 
        _cameraRotator.Rotate(offset);
    }

    private void Jump()
    {
        _playerMover.Jump();
    }
}
