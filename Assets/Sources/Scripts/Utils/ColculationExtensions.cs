using UnityEngine;

public static class ColculationExtensions 
{
    private const float Epsilon = 0.01f;

    public static bool LessThenEpsilon(this float value)
    {
        return value < Epsilon;
    }

    public static bool MoreThenEpsilon(this float value)
    {
        return value > Epsilon;
    }
}
