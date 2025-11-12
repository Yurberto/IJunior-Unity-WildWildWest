public class HeroMoveOnGroundState : HeroMoveState, IEnterableState, IExitableState
{
    private readonly IPlayerAnimator _animator;
    private readonly IWeaponPositionController _weaponPositionController;

    public HeroMoveOnGroundState
        (
        IPlayerAnimator animator,
        IWeaponPositionController weaponPositionController,
        IInputService inputService,
        IHeroView heroView,
        ICameraView cameraView,
        IMover mover,
        IRotator rotator
        )
        : base(inputService, heroView, cameraView, mover, rotator)
    {
        _animator = animator;
        _weaponPositionController = weaponPositionController;
    }

    public void Enter()
    {
        UnityEngine.Debug.Log("MoveOnGround_ENTER");

        _weaponPositionController.OnMove();
        _animator.OnMove();
        InputService.JumpButtonPressed += ChangeToJumpState;
    }

    public void Exit()
    {
        UnityEngine.Debug.Log("MoveOnGround_EXIT");
        InputService.JumpButtonPressed -= ChangeToJumpState;
    }

    public override void Update()
    {
        if (InputService.MoveDirection.sqrMagnitude.LessThenEpsilon())
        {
            Mover.Stop();
            ChangeToIdleState();
            return;
        }

        base.Update();
    }

    private void ChangeToJumpState()
    {
        StateChanger.ChangeState<HeroJumpState>();
    }

    private void ChangeToIdleState()
    {
        StateChanger.ChangeState<HeroIdleState>();
    }
}
