using Unity.VisualScripting;
using UnityEngine;

public class ThirdPersonCameraService
{
    private readonly ICameraSetting _cameraSetting;
    private readonly IInputService _inputService;

    private Transform _camera;
    private Transform _target;

    private float _mouseX;
    private float _mouseY;

    public ThirdPersonCameraService(ICameraSetting cameraSetting, IInputService inputService, Transform camera, Transform target)
    {
        _cameraSetting = cameraSetting;
        _inputService = inputService;
        _camera = camera;
        _target = target;
    }

    public void Initialize()
    {
        _inputService.MouseDeltaUpdated += UpdateLook;
    }

    public void Dispose()
    {
        _inputService.MouseDeltaUpdated -= UpdateLook;
    }

    public void UpdateCamera()
    {
        _mouseY = Mathf.Clamp(_mouseY, _cameraSetting.MinYAngle, _cameraSetting.MaxYAngle);

        Quaternion rotation = Quaternion.Euler(_mouseY, _mouseX, 0);
        Vector3 offset = rotation * new Vector3(_cameraSetting.OffsetX, 0, -_cameraSetting.Distance);
        Vector3 desiredPosition = _target.position + Vector3.up * _cameraSetting.Height + offset;

        _camera.position = desiredPosition;
        _camera.LookAt(_target.position + Vector3.up * _cameraSetting.Height);
    }

    private void UpdateLook(Vector2 mouseDelta)
    {
        _mouseX += mouseDelta.x * _cameraSetting.RotateSpeed * Time.deltaTime;
        _mouseY += mouseDelta.y * _cameraSetting.RotateSpeed * Time.deltaTime;
    }
}
