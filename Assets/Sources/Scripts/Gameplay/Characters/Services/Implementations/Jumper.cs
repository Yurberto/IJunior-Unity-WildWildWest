using UnityEngine;

public class Jumper : IJumper
{
    private Rigidbody _rigidbody;

    public Jumper(Rigidbody rigidbody) =>
        _rigidbody = rigidbody;

    public Vector3 Velocity => _rigidbody.velocity;

    public void Jump(float force)
    {
        _rigidbody.AddForce(_rigidbody.transform.up * force, ForceMode.Impulse);
    }
}
