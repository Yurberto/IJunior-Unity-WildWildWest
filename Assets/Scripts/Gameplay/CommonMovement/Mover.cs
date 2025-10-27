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
        Vector3 correctDirection = new Vector3(direction.x, _rigidbody.velocity.y, direction.z).normalized;

        _rigidbody.velocity = correctDirection * _speed;
    }
}
