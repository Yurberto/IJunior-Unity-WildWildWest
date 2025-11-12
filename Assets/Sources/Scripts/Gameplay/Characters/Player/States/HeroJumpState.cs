using UnityEngine;

public class HeroJumpState : HeroMoveState, IEnterableState, IExitableState, IUpdatableState, IFixableState
{
    private readonly IPlayerAnimator _animator;
    private readonly IWeaponPositionController _weaponPositionController;

    private readonly IGroundDetector _groundDetector;
    private readonly IJumper _jumper;

    private bool _hasLeftGround = false;

    public HeroJumpState
        (
        IPlayerAnimator animator,
        IWeaponPositionController weaponPositionController,
        IInputService inputService,
        IGroundDetector groundDetector,
        IHeroView heroView,
        ICameraView cameraView,
        IMover mover,
        IJumper jumper,
        IRotator rotator
        ) : base(inputService, heroView, cameraView, mover, rotator)
    {
        _animator = animator;
        _weaponPositionController = weaponPositionController;
        _groundDetector = groundDetector;
        _jumper = jumper;
    }

    public void Enter()
    {
        Debug.Log("Jump_ENTER");

        _weaponPositionController.OnJump();
        _animator.OnJump();
        _jumper.Jump(HeroView.PlayerSetting.JumpForce);
    }

    public void Exit()
    {
        _hasLeftGround = false;
    }

    public override void FixedUpdate()
    {
        Vector3 direction = CalculateCurrentDirection();
        float airMoveSpeed = HeroView.PlayerSetting.MoveSpeed * HeroView.PlayerSetting.MoveInAirFactor;

        Mover.Move(airMoveSpeed * Time.fixedDeltaTime, direction);
    }

    public override void Update()
    {
        if (_hasLeftGround == false)
        {
            _hasLeftGround = HeroView.Rigidbody.velocity.y.MoreThenEpsilon();
        }

        if (_hasLeftGround && _groundDetector.IsGrounded() && HeroView.Rigidbody.velocity.y.LessThenEpsilon())
        {
            if (HeroView.Rigidbody.velocity.x.MoreThenEpsilon() || HeroView.Rigidbody.velocity.z.MoreThenEpsilon()) 
                ChangeToMoveOnGround();
            else
                ChangeToIdle();
        }

        base.Update();
    }

    private void ChangeToMoveOnGround()
    {
        StateChanger.ChangeState<HeroMoveOnGroundState>();
    }

    private void ChangeToIdle()
    {
        StateChanger.ChangeState<HeroIdleState>();
    }
}
