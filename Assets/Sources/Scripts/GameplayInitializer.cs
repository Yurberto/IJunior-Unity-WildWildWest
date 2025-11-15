using UnityEngine;

public class GameplayInitializer : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private PlayerCamera _playerCamera;
    [SerializeField] private WeaponPositionController _weaponPositionController;

    private InputService _inputService;

    private void Awake()
    {
        _inputService = new InputService();
        _inputService.Initialize();

        InitialzePlayer(_inputService);
    }

    private void OnDisable()
    {
        _inputService.Dispose();
    }

    private void InitialzePlayer(IInputService inputService)
    {
        IMover mover = new Mover(_hero.Rigidbody);
        IJumper jumper = new Jumper(_hero.Rigidbody);
        IRotator rotator = new Rotator();
        IPlayerAnimator animator = new PlayerAnimator(_playerAnimator);
        IShooter shooter = new Shooter(_playerCamera.transform, _hero.Weapon, LayerData.Enemy);

        HeroStateMachineFactory stateMachineFactory = new(animator, inputService, _weaponPositionController, mover, jumper, rotator, shooter, _hero, _playerCamera);
        StateMachine heroStateMachine = stateMachineFactory.Create();

        _hero.Construct(heroStateMachine);
        _playerCamera.Construct(_inputService);
    }
}
