using UnityEngine;

public class Shooter : IShooter
{
    private IWeapon _weapon;
    private Transform _camera;
    private LayerMask _hitMask;

    private Raycaster _raycaster;

    public Shooter(Transform cameraPosition, IWeapon weapon, LayerMask hitMask)
    {
        _camera = cameraPosition;
        _weapon = weapon;
        _hitMask = hitMask;

        _raycaster = new(_weapon.Setting.Range, _weapon.Setting.PiercelLimit, _hitMask);
    }

    public void Shoot()
    {
        if (_weapon.CanShoot == false)
        {
            if (_weapon.CurrentBulletsCount == 0)
            {
                _weapon.Reload();
                return;
            }
        }

        RaycastHit hit = _raycaster.Cast(_camera.position, _camera.forward);

        if (hit.collider.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(_weapon.Setting.Damage);

        _weapon.SpendBullet();
    }
}
