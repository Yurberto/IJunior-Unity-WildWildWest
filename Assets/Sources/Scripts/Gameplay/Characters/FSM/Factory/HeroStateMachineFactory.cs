using System.Collections.Generic;

public class HeroStateMachineFactory 
{
    private readonly IPlayerAnimator _animator;
    private readonly IInputService _inputService;
    private readonly IWeaponPositionController _weaponPositionController;

    private readonly IMover _mover;
    private readonly IJumper _jumper;
    private readonly IRotator _rotator;

    private readonly IHeroView _heroView;
    private readonly ICameraView _cameraView;

    public HeroStateMachineFactory
        (
        IPlayerAnimator playerAnimator,
        IInputService inputService, 
        IWeaponPositionController weaponPositionController,
        IMover mover, IJumper jumper,
        IRotator rotator,
        IHeroView heroView, 
        ICameraView cameraView
        )
    {
        _animator = playerAnimator;
        _inputService = inputService;
        _weaponPositionController = weaponPositionController;
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
            new HeroIdleState(_animator, _inputService, _weaponPositionController),
            new HeroMoveOnGroundState(_animator, _weaponPositionController, _inputService, _heroView, _cameraView, _mover, _rotator),
            new HeroJumpState(_animator, _weaponPositionController, _inputService, _heroView.GroundDetector, _heroView, _cameraView, _mover, _jumper, _rotator)
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
