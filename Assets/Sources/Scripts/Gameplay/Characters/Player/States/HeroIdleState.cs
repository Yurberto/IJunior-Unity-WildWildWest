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
        UnityEngine.Debug.Log("Idle_ENTER");

        _inputService.JumpButtonPressed += ChangeToJumpState;
    }

    public void Exit()
    {
        UnityEngine.Debug.Log("Idle_Exit");

        _inputService.JumpButtonPressed -= ChangeToJumpState;
    }

    public void Update()
    {
        if (_inputService.MoveDirection.sqrMagnitude.MoreThenEpsilon())
            ChangeToMoveOnGroundState();
    }

    private void ChangeToJumpState()
    {
        _stateChanger.ChangeState<HeroJumpState>();
    }

    private void ChangeToMoveOnGroundState()
    {
        _stateChanger.ChangeState<HeroMoveOnGroundState>();
    }
}
