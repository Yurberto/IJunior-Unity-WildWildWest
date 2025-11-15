public class HeroIdleState : IEnterableState, IUpdatableState, IExitableState
{
    private readonly IPlayerAnimator _animator;
    private readonly IInputService _inputService;

    private readonly IWeaponPositionController _weaponPositionController;

    private IStateChanger _stateChanger;

    public HeroIdleState(IPlayerAnimator playerAnimator, IInputService inputService, IWeaponPositionController weaponPositionController)
    {
        _animator = playerAnimator;
        _inputService = inputService;
        _weaponPositionController = weaponPositionController;
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }

    public void Enter()
    {
        UnityEngine.Debug.Log("Idle_ENTER");
        _animator.OnIdle();
        _weaponPositionController.OnIdle();

        _inputService.JumpPressed += ChangeToJumpState;
        _inputService.ShootPressed += ChangeToAttackState;
    }

    public void Exit()
    {
        UnityEngine.Debug.Log("Idle_Exit");

        _inputService.JumpPressed -= ChangeToJumpState;
        _inputService.ShootPressed -= ChangeToAttackState;
    }

    public void Update()
    {
        if (_inputService.MoveDirection.sqrMagnitude.MoreThenEpsilon())
            ChangeToMoveOnGroundState();
    }

    private void ChangeToJumpState() =>
        _stateChanger.ChangeState<HeroJumpState>();

    private void ChangeToMoveOnGroundState() =>
        _stateChanger.ChangeState<HeroMoveOnGroundState>();

    private void ChangeToAttackState() =>
        _stateChanger.ChangeState<HeroAttackState>();
}
