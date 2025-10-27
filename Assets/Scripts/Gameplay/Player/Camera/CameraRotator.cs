using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _head;

    [SerializeField, Range(0.0f, 100.0f)] private float _sensitivity = 50.0f;
    [SerializeField, Range(0.0f, 0.5f)] private float _deadZone = 0.1f;
    [SerializeField, Range(0.0f, 90f)] private float _maxVerticalAngle = 80f;
    [SerializeField, Range(-90f, 0.0f)] private float _minVerticalAngle = -80f;

    private float _currentRotationY = 0;
    private float _currentRotationX = 0;

    Quaternion _currentRotation;

    private void Start()
    {
        _camera.transform.rotation = Quaternion.identity;
        _head.transform.rotation = Quaternion.identity;
    }

    public void Rotate(Vector2 mouseDelta)
    {
        if (mouseDelta.sqrMagnitude < _deadZone)
            return;

        float mouseX = mouseDelta.x * _sensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * _sensitivity * Time.deltaTime;

        _currentRotationY += mouseY;

        _currentRotationX += mouseX;
        _currentRotationX = Mathf.Clamp(_currentRotationX, _minVerticalAngle, _maxVerticalAngle);

        _currentRotation = Quaternion.Euler(_currentRotationX, _currentRotationY, 0.0f);

        _camera.transform.localRotation = _currentRotation;
        _head.transform.localRotation = _currentRotation;
    }
}
