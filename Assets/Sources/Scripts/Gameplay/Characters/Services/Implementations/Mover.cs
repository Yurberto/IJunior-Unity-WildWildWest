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

        Vector3 targetVeclocity = direction.normalized * moveSpeed;
        targetVeclocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = targetVeclocity;
    }

    public void Stop() =>
        _rigidbody.velocity = new Vector3(0.0f, _rigidbody.velocity.y, 0.0f);
}
