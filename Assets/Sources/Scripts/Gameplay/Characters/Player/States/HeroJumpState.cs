using UnityEngine;

public class HeroJumpState : IEnterableState, IExitableState, IUpdatableState, IFixableState
{
    private readonly IInputService _inputService;
    private readonly IGroundDetector _groundDetector;

    private readonly IHeroView _heroView;
    private readonly ICameraView _cameraView;

    private readonly IAirMover _airMover;
    private readonly IJumper _jumper;
    private readonly IRotator _rotator;

    private IStateChanger _stateChanger;

    private bool _hasLeftGround = false;

    public HeroJumpState(IInputService inputService, IGroundDetector groundDetector, IHeroView heroView, ICameraView cameraView, IAirMover mover, IJumper jumper, IRotator rotator)
    {
        _inputService = inputService;
        _groundDetector = groundDetector;

        _heroView = heroView;
        _cameraView = cameraView;

        _airMover = mover;
        _jumper = jumper;
        _rotator = rotator;
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }

    public void Enter()
    {
        Debug.Log("Jump_ENTER");
        _jumper.Jump(_heroView.PlayerSetting.JumpForce);
    }

    public void Exit()
    {
        _hasLeftGround = false;
    }

    public void FixedUpdate()
    {
        Vector3 direction = CalculateCurrentDirection();
        float airMoveSpeed = _heroView.PlayerSetting.MoveSpeed * _heroView.PlayerSetting.MoveInAirFactor;

        _airMover.MoveInAir(airMoveSpeed * Time.fixedDeltaTime, direction);
    }

    public void Update()
    {
        if (_hasLeftGround == false)
        {
            _hasLeftGround = _heroView.Rigidbody.velocity.y.MoreThenEpsilon();
        }

        if (_hasLeftGround && _groundDetector.IsGrounded() && _heroView.Rigidbody.velocity.y.LessThenEpsilon())
        {
            if (_heroView.Rigidbody.velocity.x.MoreThenEpsilon() || _heroView.Rigidbody.velocity.z.MoreThenEpsilon()) 
                ChangeToMoveOnGround();
            else
                ChangeToIdle();
        }

        Vector3 direction = CalculateCurrentDirection();
        _rotator.RotateToDirection(_heroView.transform, direction, _heroView.PlayerSetting.RotateSpeed * Time.deltaTime);
    }

    private void ChangeToMoveOnGround()
    {
        _stateChanger.ChangeState<HeroMoveOnGroundState>();
    }

    private void ChangeToIdle()
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
