using UnityEngine;

public class Hero : MonoBehaviour, IHeroView
{
    [SerializeField] private PlayerSetting _playerSetting;
    [SerializeField] private GroundDetector _groundDetector;

    private IStateMachineUpdater _stateMachineUpdater;

    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

    public IPlayerSetting PlayerSetting => _playerSetting;
    public IGroundDetector GroundDetector => _groundDetector;

    public void Construct(IStateMachineUpdater stateMachineUpdater)
    {
        _stateMachineUpdater = stateMachineUpdater;
    }

    private void FixedUpdate() =>
        _stateMachineUpdater.FixedUpdateState();

    private void Update() =>
        _stateMachineUpdater.UpdateState();

    private void LateUpdate() =>
        _stateMachineUpdater.LateUpdateState();
}
