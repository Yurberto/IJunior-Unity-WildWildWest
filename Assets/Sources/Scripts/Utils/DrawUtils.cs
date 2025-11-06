using UnityEngine;

public static class DrawUtils
{
    public static void DrawBox(Vector3 center, Vector3 halfExtents, Color color, float duration = 1f, Quaternion rotation = default)
    {
        if (rotation == default)
            rotation = Quaternion.identity;

        Vector3[] vertices = new Vector3[8];

        Vector3[] localVertices = {
            new Vector3(-halfExtents.x, -halfExtents.y, -halfExtents.z),
            new Vector3(-halfExtents.x, -halfExtents.y,  halfExtents.z),
            new Vector3(-halfExtents.x,  halfExtents.y, -halfExtents.z),
            new Vector3(-halfExtents.x,  halfExtents.y,  halfExtents.z),
            new Vector3( halfExtents.x, -halfExtents.y, -halfExtents.z),
            new Vector3( halfExtents.x, -halfExtents.y,  halfExtents.z),
            new Vector3( halfExtents.x,  halfExtents.y, -halfExtents.z),
            new Vector3( halfExtents.x,  halfExtents.y,  halfExtents.z)
        };

        for (int i = 0; i < 8; i++)
        {
            vertices[i] = center + rotation * localVertices[i];
        }

        Debug.DrawLine(vertices[0], vertices[1], color, duration);
        Debug.DrawLine(vertices[1], vertices[5], color, duration);
        Debug.DrawLine(vertices[5], vertices[4], color, duration);
        Debug.DrawLine(vertices[4], vertices[0], color, duration);

        Debug.DrawLine(vertices[2], vertices[3], color, duration);
        Debug.DrawLine(vertices[3], vertices[7], color, duration);
        Debug.DrawLine(vertices[7], vertices[6], color, duration);
        Debug.DrawLine(vertices[6], vertices[2], color, duration);

        Debug.DrawLine(vertices[0], vertices[2], color, duration);
        Debug.DrawLine(vertices[1], vertices[3], color, duration);
        Debug.DrawLine(vertices[4], vertices[6], color, duration);
        Debug.DrawLine(vertices[5], vertices[7], color, duration);
    }
}