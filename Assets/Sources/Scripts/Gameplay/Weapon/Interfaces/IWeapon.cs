public interface IWeapon
{
    public bool CanShoot { get; }
    public int CurrentBulletsCount { get; }
    public IWeaponSetting Setting { get; }

    public void SpendBullet();
    public void Reload();
    public void WaitShootDelay();
}
