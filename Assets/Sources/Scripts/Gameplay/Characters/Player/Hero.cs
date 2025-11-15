using UnityEngine;

public class Hero : MonoBehaviour, IHeroView, IDamageable
{
    [SerializeField] private PlayerSetting _playerSetting;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Weapon _weapon;
    
    private IStateMachineUpdater _stateMachineUpdater;

    private IHealth _health;

    public Rigidbody Rigidbody => _rigidbody;

    public IPlayerSetting PlayerSetting => _playerSetting;
    public IGroundDetector GroundDetector => _groundDetector;
    public IWeapon Weapon => _weapon;

    public void Construct(IStateMachineUpdater stateMachineUpdater)
    {
        _stateMachineUpdater = stateMachineUpdater;

        _health = new Health(_playerSetting.MaxHealth, _playerSetting.MaxHealth);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    private void FixedUpdate() =>
        _stateMachineUpdater.FixedUpdateState();

    private void Update() =>
        _stateMachineUpdater.UpdateState();

    private void LateUpdate() =>
        _stateMachineUpdater.LateUpdateState();
}
