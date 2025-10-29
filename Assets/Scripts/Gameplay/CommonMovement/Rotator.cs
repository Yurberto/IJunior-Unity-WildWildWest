using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField, Range(0.0f, 100.0f)] private float _rotationSpeed = 10f;

    public void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Vector3 smoothedForward = Vector3.Slerp(transform.forward, direction, _rotationSpeed * Time.deltaTime);
            transform.forward = smoothedForward;
        }
    }
}
