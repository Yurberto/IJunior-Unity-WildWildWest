using UnityEngine;

public class WeaponPositionController : MonoBehaviour, IWeaponPositionController
{
    [SerializeField] private Transform _idlePoint;
    [SerializeField] private Transform _movePoint;
    [SerializeField] private Transform _jumpPoint;

    private Transform _current;

    public void OnIdle()
    {
        _current = _idlePoint;
    }

    public void OnMove()
    {
        _current = _movePoint;
    }

    public void OnJump()
    {
        _current = _jumpPoint;
    }

    private void LateUpdate()
    {
        transform.position = _current.position;
        transform.rotation = _current.rotation;
    }
}
