using UnityEngine;

public abstract class HeroMoveState : IFixableState, IUpdatableState
{
    protected readonly IInputService InputService;
    protected readonly IHeroView HeroView;
    protected readonly ICameraView CameraView;

    protected readonly IMover Mover;
    protected readonly IRotator Rotator;

    protected IStateChanger StateChanger;

    public HeroMoveState(IInputService inputService, IHeroView heroView, ICameraView cameraView, IMover mover, IRotator rotator)
    {
        InputService = inputService;
        HeroView = heroView;
        CameraView = cameraView;
        Mover = mover;
        Rotator = rotator;
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        Debug.Log($"SetStateChanger HeroMoveState");
        StateChanger = stateChanger;
    }

    public virtual void FixedUpdate()
    {
        Vector3 direction = CalculateCurrentDirection();
        Mover.Move(HeroView.PlayerSetting.MoveSpeed * Time.fixedDeltaTime, direction);
    }

    public virtual void Update()
    {
        Vector3 direction = CalculateCurrentDirection();
        Rotator.RotateToDirection(HeroView.transform, direction, HeroView.PlayerSetting.RotateSpeed * Time.deltaTime);
    }

    protected Vector3 CalculateCurrentDirection()
    {
        Vector3 cameraForward = CameraView.transform.forward;
        Vector3 cameraRight = CameraView.transform.right;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 currentDirection = cameraForward * InputService.MoveDirection.z + cameraRight * InputService.MoveDirection.x;

        return currentDirection;
    }
}
