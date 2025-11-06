using UnityEngine;

public interface IRotator
{
    public void RotateToDirection(Transform rotatable, Vector3 direction, float rotationSpeed);
}
