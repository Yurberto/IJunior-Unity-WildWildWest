using UnityEngine;

public class Mover : IMover
{
    private Rigidbody _rigidbody;

    public Mover(Rigidbody rigidbody) =>
        _rigidbody = rigidbody;

    public void Move(float moveSpeed, Vector3 direction)
    {
        if (direction.sqrMagnitude.LessThenEpsilon())
            return;

        Vector3 targetPosition = _rigidbody.position + direction.normalized * moveSpeed;

        _rigidbody.MovePosition(targetPosition);
    }

    public void Stop() =>
        _rigidbody.velocity = Vector3.zero;
}
