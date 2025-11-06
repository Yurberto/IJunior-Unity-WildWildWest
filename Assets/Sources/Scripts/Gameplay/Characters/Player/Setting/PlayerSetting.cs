using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSetting", menuName = "ScriptableObject/PlayerSetting")]
public class PlayerSetting : ScriptableObject, IPlayerSetting
{
    [field: SerializeField] public float MoveSpeed { get; private set; }

    [field: SerializeField] public float RotateSpeed { get; private set; }

    [field: SerializeField] public float JumpForce { get; private set; }
}
