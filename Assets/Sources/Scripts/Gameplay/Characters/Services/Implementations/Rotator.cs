using UnityEngine;

public class Rotator : IRotator
{
    public void RotateToDirection(Transform rotatable, Vector3 direction, float rotationSpeed)
    {
        if (direction.sqrMagnitude.LessThenEpsilon())
            return;

        direction.y = 0;
        direction.Normalize();

        Rotate(rotatable, direction, rotationSpeed);
    }

    private void Rotate(Transform rotatable, Vector3 direction, float rotationSpeed)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        rotatable.rotation = Quaternion.Slerp(rotatable.rotation, targetRotation, rotationSpeed);
    }
}
