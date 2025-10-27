using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    private const float SpeedMultiplier = 1000f;

    [SerializeField, Range(0.0f, 100.0f)] private float _rotationSpeed = 100.0f;

    public void LookAt(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion targetRotationY = Quaternion.Euler(0.0f, targetRotation.y, 0.0f);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationY, _rotationSpeed * SpeedMultiplier * Time.deltaTime);
    }
}
