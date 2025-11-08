using System.Collections.Generic;

public class HeroStateMachineFactory 
{
    private readonly IInputService _inputService;

    private readonly IMover _mover;
    private readonly IJumper _jumper;
    private readonly IRotator _rotator;

    private readonly IHeroView _heroView;
    private readonly ICameraView _cameraView;

    public HeroStateMachineFactory(IInputService inputService, IMover mover, IJumper jumper, IRotator rotator, IHeroView heroView, ICameraView cameraView)
    {
        _inputService = inputService;
        _mover = mover;
        _jumper = jumper;
        _rotator = rotator;
        _heroView = heroView;
        _cameraView = cameraView;
    }

    public StateMachine Create()
    {
        List<IState> exitableStates = new List<IState>()
        {
            new HeroIdleState(_inputService),
            new HeroMoveOnGroundState(_inputService, _heroView, _cameraView, _mover, _rotator),
            new HeroJumpState(_inputService, _heroView.GroundDetector, _heroView, _cameraView, _mover, _jumper, _rotator)
        };

        StateMachine heroStateMachine = new StateMachine(exitableStates);

        for (int i = 0; i < exitableStates.Count; i++)
        {
            exitableStates[i].SetStateChanger(heroStateMachine);
        }

        heroStateMachine.ChangeState<HeroIdleState>();

        return heroStateMachine;
    }
}
