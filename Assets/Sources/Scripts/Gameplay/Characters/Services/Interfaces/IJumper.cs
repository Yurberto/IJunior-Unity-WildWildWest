using UnityEngine;

public interface IJumper 
{
    public Vector3 Velocity { get; }

    public void Jump(float force);
}
