using UnityEngine;

public class GroundDetector : MonoBehaviour, IGroundDetector
{
    private const int OverlapValue = 1;

    [SerializeField] private Transform _boxCenterPoint;
    [SerializeField] private Vector3 _boxHalfExtents;

    Collider[] _hitted = new Collider[OverlapValue];

    public bool IsGrounded()
    {
        int count = Physics.OverlapBoxNonAlloc(_boxCenterPoint.position, _boxHalfExtents, _hitted, Quaternion.identity, LayerData.Ground);
        DrawUtils.DrawBox(_boxCenterPoint.position, _boxHalfExtents, Color.red);

        return count > 0;
    }
}
