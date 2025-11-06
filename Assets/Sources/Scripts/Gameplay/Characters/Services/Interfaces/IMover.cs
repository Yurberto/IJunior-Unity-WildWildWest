using UnityEngine;

public interface IMover
{
    public void Move(float moveSpeed, Vector3 direction);

    public void Stop();
}
