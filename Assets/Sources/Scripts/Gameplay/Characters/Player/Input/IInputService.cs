using System;
using UnityEngine;

public interface IInputService
{
    public event Action JumpPressed;

    public event Action ShootPressed;
    public event Action ShootReleased;

    public event Action GetMainWeaponPressed;
    public event Action GetNextWeaponPressed;
    public event Action PutAwayWeaponPressed;

    public event Action<Vector2> MouseDeltaUpdated;

    public Vector3 MoveDirection { get; }
}