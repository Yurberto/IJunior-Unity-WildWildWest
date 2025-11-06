using UnityEngine;

public class HeroIdleState : IEnterableState, IUpdatableState, IExitableState
{
    private readonly IInputService _inputService;

    private IStateChanger _stateChanger;

    public HeroIdleState(IInputService inputService)
    {
        _inputService = inputService;
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }

    public void Enter()
    {
        _inputService.JumpButtonPressed += ChangeToJumpState;
        Debug.Log("IdleStateEnter");
    }

    public void Exit()
    {
        _inputService.JumpButtonPressed -= ChangeToJumpState;
        Debug.Log("IdleStateExit");
    }

    public void Update()
    {
        if (_inputService.MoveDirection.sqrMagnitude.MoreThenEpsilon())
            ChangeToMoveState();
    }

    private void ChangeToJumpState()
    {
        _stateChanger.ChangeState<HeroJumpState>();
    }

    private void ChangeToMoveState()
    {
        _stateChanger.ChangeState<HeroMoveState>();
    }
}
