using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform _body;
    [SerializeField, Range(0.0f, 100.0f)] private float _rotationSpeed = 10f;

    public void RotateBody(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotaion = Quaternion.LookRotation(direction);

            _body.rotation = Quaternion.Slerp(_body.rotation, targetRotaion, _rotationSpeed * Time.deltaTime);
        }
    }
}
