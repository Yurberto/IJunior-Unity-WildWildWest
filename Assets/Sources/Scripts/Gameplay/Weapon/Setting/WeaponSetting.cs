using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponSetting), menuName = nameof(ScriptableObject) + "/" + nameof(WeaponSetting))]
public class WeaponSetting : ScriptableObject, IWeaponSetting
{
    [field: SerializeField, Min(0f)] public float Damage { get; private set; } = 5f;
    [field: SerializeField, Min(0f)] public float ShootDelay { get; private set; } = 0.3f;
    [field: SerializeField, Min(0f)] public float Range { get; private set; } = 100f;
    [field: SerializeField, Min(0f)] public float ReloadTime { get; private set; } = 1.3f;
    [field: SerializeField, Min(0f)] public int PiercelLimit { get; private set; } = 1;
    [field: SerializeField, Min(0)] public int BulletsInClip { get; private set; } = 30;
}
