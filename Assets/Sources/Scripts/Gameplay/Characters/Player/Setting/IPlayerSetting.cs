public interface IPlayerSetting
{
    public float MoveSpeed { get; }
    public float RotateSpeed { get; }
    public float JumpForce { get; }
    public float MoveInAirFactor { get; }
    public float MaxHealth { get; }
}