using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    private const float SpeedDivider = 100f;

    [SerializeField] private Transform _body;
    [SerializeField, Range(0.0f, 100.0f)] private float _rotationSpeed = 1.2f;

    public void LookAt(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Vector3 smoothedForward = Vector3.Slerp(_body.forward, direction, _rotationSpeed / SpeedDivider);
            _body.forward = smoothedForward;
        }
    }

    public void Rotate(Vector2 mouseDelta)
    {
        
    }
}
