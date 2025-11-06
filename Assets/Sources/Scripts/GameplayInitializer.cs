using UnityEngine;

public class GameplayInitializer : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private PlayerCamera _playerCamera;

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

        HeroStateMachineFactory stateMachineFactory = new(inputService, mover, jumper, rotator, _hero, _playerCamera);
        StateMachine heroStateMachine = stateMachineFactory.Create();
        _hero.Construct(heroStateMachine);
    }
}
