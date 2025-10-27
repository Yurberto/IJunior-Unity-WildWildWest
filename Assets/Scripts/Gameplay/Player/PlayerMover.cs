using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(CharacterRotator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private CharacterRotator _rotator;

    public void Move(Vector3 direction)
    {
        _mover.Move(direction);
    }

    public void LookAt(Vector3 direction)
    {
        _rotator.LookAt(direction);
    }

    public void Jump()
    {
        _jumper.Jump();
    }
}
