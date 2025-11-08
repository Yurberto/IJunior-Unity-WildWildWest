using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerCameraSetting), menuName = "ScriptableObject/" + nameof(PlayerCameraSetting))]
public class PlayerCameraSetting : ScriptableObject, ICameraSetting
{
    [field: SerializeField] public float Height { get; private set; } = 2.15f;
    [field: SerializeField] public float Distance { get; private set; } = -2.3f;
    [field: SerializeField] public float OffsetX { get; private set; } = 0.7f;
    [field: SerializeField] public float MinYAngle { get; private set; } = -40f;
    [field: SerializeField] public float MaxYAngle { get; private set; } = 80f;
    [field: SerializeField] public float RotateSpeed { get; private set; } = 120f;
}
