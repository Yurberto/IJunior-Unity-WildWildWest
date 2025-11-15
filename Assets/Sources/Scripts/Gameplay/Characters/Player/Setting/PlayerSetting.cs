using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSetting", menuName = "ScriptableObject/PlayerSetting")]
public class PlayerSetting : ScriptableObject, IPlayerSetting
{
    [field: SerializeField] public float MoveSpeed { get; private set; } = 150;
    [field: SerializeField] public float RotateSpeed { get; private set; } = 7;
    [field: SerializeField] public float JumpForce { get; private set; } = 5;
    [field: SerializeField] public float MoveInAirFactor { get; private set; } = 0.7f;
    [field: SerializeField] public float MaxHealth { get; private set; } = 100f;
}
