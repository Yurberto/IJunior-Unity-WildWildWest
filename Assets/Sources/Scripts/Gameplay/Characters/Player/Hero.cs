using UnityEngine;

public class Hero : MonoBehaviour, IHeroView
{
    [SerializeField] private PlayerSetting _playerSetting;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Rigidbody _rigidbody;

    private IStateMachineUpdater _stateMachineUpdater;

    public Rigidbody Rigidbody => _rigidbody;

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
