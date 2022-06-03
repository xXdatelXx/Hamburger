using UnityEngine;

public static class VectorExtension
{
    public static Vector3 Clamp(this Vector3 position, Vector2 upLeftPosition, Vector2 bottomRightPosition)
    {
        float x = Mathf.Clamp(position.x, upLeftPosition.x, bottomRightPosition.x);
        float y = Mathf.Clamp(position.y, bottomRightPosition.y, upLeftPosition.y);

        return new Vector2(x, y);
    }
}
