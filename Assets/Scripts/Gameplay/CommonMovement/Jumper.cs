using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour
{
    [SerializeField, Range(0.0f, 20.0f)] private float _jumpForce = 5.0f;

    private Rigidbody _rigigbody;

    private void Awake()
    {
        _rigigbody = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        _rigigbody.AddForce(new Vector3(0.0f, _jumpForce, 0.0f), ForceMode.Impulse);
    }
}
