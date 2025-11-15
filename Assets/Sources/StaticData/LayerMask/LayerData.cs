using UnityEngine;

public static class LayerData
{
    public static readonly LayerMask Ground = LayerMask.GetMask(nameof(Ground));
    public static readonly LayerMask Enemy = LayerMask.GetMask(nameof(Enemy));
}
