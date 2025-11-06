using UnityEngine;

public class HeroMoveState : IEnterableState, IExitableState, IFixableState, IUpdatableState
{
    private readonly IInputService _inputService;

    private readonly IMover _mover;
    private readonly IRotator _rotator;

    private readonly IHeroView _heroView;
    private readonly ICameraView _cameraView;

    private IStateChanger _stateChanger;

    public HeroMoveState(IInputService inputService, IMover mover, IRotator rotator, IHeroView heroView, ICameraView cameraView)
    {
        _inputService = inputService;
        _mover = mover;
        _rotator = rotator;
        _heroView = heroView;
        _cameraView = cameraView;
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }

    public void Enter()
    {
        _inputService.JumpButtonPressed += ChangeToJumpState;
    }

    public void Exit()
    {
        _inputService.JumpButtonPressed -= ChangeToJumpState;
    }

    public void FixedUpdate()
    {
        Vector3 direction = CalculateCurrentDirection();
        _mover.Move(_heroView.PlayerSetting.MoveSpeed * Time.fixedDeltaTime, direction);
    }

    public void Update()
    {
        if (_inputService.MoveDirection.sqrMagnitude.LessThenEpsilon())
        {
            _mover.Stop();
            ChangeToIdleState();
            return;
        }

        Vector3 direction = CalculateCurrentDirection();
        _rotator.RotateToDirection(_heroView.transform, direction, _heroView.PlayerSetting.RotateSpeed * Time.deltaTime);
    }

    private void ChangeToJumpState()
    {
        _stateChanger.ChangeState<HeroJumpState>();
    }

    private void ChangeToIdleState()
    {
        _stateChanger.ChangeState<HeroIdleState>();
    }

    private Vector3 CalculateCurrentDirection()
    {
        Vector3 cameraForward = _cameraView.transform.forward;
        Vector3 cameraRight = _cameraView.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 currentDirection = cameraForward * _inputService.MoveDirection.z + cameraRight * _inputService.MoveDirection.x;

        return currentDirection;
    }
}
