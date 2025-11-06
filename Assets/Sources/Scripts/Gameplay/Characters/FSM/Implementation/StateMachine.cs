using System;
using System.Collections.Generic;
using System.Linq;

public class StateMachine : IStateChanger, IStateMachineUpdater
{
    private Dictionary<Type, IExitableState> _states;

    private IExitableState _currentState;

    public StateMachine(List<IExitableState> states)
    {
        _states = states.ToDictionary(type => type.GetType(), value => value);
    }

    public void ChangeState<T>() where T : IExitableState
    {
        if (_states.TryGetValue(typeof(T), out IExitableState newState))
            ChangeState(newState);
        else
            throw new Exception($"State {typeof(T)} doesnt exist in StateMachine");
    }

    public void FixedUpdateState()
    {
        if (_currentState is IFixableState fixableState)
            fixableState.FixedUpdate();
    }

    public void LateUpdateState()
    {
        if (_currentState is ILatableState LatableState)
            LatableState.LateUpdate();
    }

    public void UpdateState()
    {
        if (_currentState is IUpdatableState updatableState)
            updatableState.Update();
    }

    private void ChangeState(IExitableState newState)
    {
        if (_currentState ==  newState)
            return;

        _currentState?.Exit();
        _currentState = newState;

        if (_currentState is IEnterableState enterableState)
            enterableState.Enter();
    }
}
