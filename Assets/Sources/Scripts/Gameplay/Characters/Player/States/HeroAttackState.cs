public class HeroAttackState : HeroMoveState, IEnterableState, IExitableState
{
    private readonly IPlayerAnimator _animator;
    private readonly IWeaponPositionController _weaponPositionController;

    private readonly IShooter _shooter;

    public HeroAttackState
        (
        IInputService inputService,
        IHeroView heroView, 
        ICameraView cameraView, 
        IMover mover, 
        IRotator rotator,
        IShooter shooter
        ) : base(inputService, heroView, cameraView, mover, rotator)
    {
        _shooter = shooter;
    }

    public void Enter()
    {
        _shooter.Shoot();

        InputService.ShootPressed += _shooter.Shoot;
        InputService.ShootReleased += ChangeState;
    }

    public void Exit()
    {
        InputService.ShootPressed -= _shooter.Shoot;
        InputService.ShootReleased -= ChangeState;
    }

    private void ChangeState()
    {
        if (InputService.MoveDirection.sqrMagnitude.MoreThenEpsilon())
            StateChanger.ChangeState<HeroMoveOnGroundState>();
        else
            StateChanger.ChangeState<HeroIdleState>();
    }
}
