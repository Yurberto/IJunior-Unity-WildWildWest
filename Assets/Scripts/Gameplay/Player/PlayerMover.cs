using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Rotator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [Space] 
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Rotator _rotator;

    public void Move(Vector3 direction)
    {
        direction = direction.x * _playerCamera.transform.right + direction.z * _playerCamera.transform.forward;
        direction.y = 0f;

        _mover.Move(direction);
    }

    public void StopMove()
    {
        _mover.Stop();
    }

    public void RotateBody(Vector3 direction)
    {
        _rotator.RotateBody(direction);
    }

    public void Jump()
    {
        _jumper.Jump();
    }
}
