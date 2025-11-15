using UnityEngine;

public class Raycaster
{
    private float _range = 0;
    private LayerMask _layerMask;

    private RaycastHit[] _hits;

    public Raycaster(float range, int hittedCount, LayerMask layerMask)
    {
        _range = range;
        _layerMask = layerMask;

        _hits = new RaycastHit[hittedCount];
    }

    public RaycastHit Cast(Vector3 start, Vector3 direction)
    {
        Physics.RaycastNonAlloc(start, direction, _hits, _range, _layerMask);

        return _hits[0];
    }
}
