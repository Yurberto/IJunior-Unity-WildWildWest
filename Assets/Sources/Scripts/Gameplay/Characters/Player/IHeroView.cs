using UnityEngine;

public interface IHeroView
{
    public Transform transform { get; }

    public IGroundDetector GroundDetector { get; }
    public IPlayerSetting PlayerSetting { get; }
}
