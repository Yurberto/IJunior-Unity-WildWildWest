public interface IWeaponSetting
{
    public float Damage { get; }
    public float ShootDelay { get; }
    public float Range { get; }
    public float ReloadTime { get; }
    public int PiercelLimit { get; }
    public int BulletsInClip { get; }
}
