using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField, Range(0.0f, 20.0f)] private float _speed = 5;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 currentVelocityY = new Vector3(0.0f, _rigidbody.velocity.y, 0.0f);

        Vector3 correctDirectionXZ = new Vector3(direction.x, 0.0f, direction.z).normalized;

        _rigidbody.velocity = currentVelocityY + (correctDirectionXZ * _speed);
    }

    public void Stop()
    {
        _rigidbody.velocity = new Vector3(0.0f, _rigidbody.velocity.y, 0.0f);
    }
}
