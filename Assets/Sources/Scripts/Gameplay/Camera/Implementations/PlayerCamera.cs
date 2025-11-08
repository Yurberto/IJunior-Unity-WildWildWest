using UnityEngine;

public class PlayerCamera : MonoBehaviour, ICameraView
{
    [SerializeField] private Transform _target;
    [SerializeField] private PlayerCameraSetting _cameraSetting;

    private ThirdPersonCameraService _cameraService;

    public void Construct(IInputService inputService)
    {
        _cameraService = new ThirdPersonCameraService(_cameraSetting, inputService, transform, _target);
        _cameraService.Initialize();
    }

    private void LateUpdate()
    {
        _cameraService.UpdateCamera();
    }

    private void OnDisable()
    {
        _cameraService?.Dispose();
    }
}
