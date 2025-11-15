using UnityEngine;

public interface IHeroView
{
    public Transform transform { get; }
    public Rigidbody Rigidbody { get; }

    public IWeapon Weapon { get; }
    public IGroundDetector GroundDetector { get; }
    public IPlayerSetting PlayerSetting { get; }
}
