using System;
using UnityEngine;

public interface IInputService
{
    public event Action JumpButtonPressed;

    public event Action ShootPressed;
    public event Action ShootReleased;

    public event Action<Vector2> MouseDeltaUpdated;

    public Vector3 MoveDirection { get; }
}