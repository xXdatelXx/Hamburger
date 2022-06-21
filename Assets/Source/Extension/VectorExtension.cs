using UnityEngine;

public static class VectorExtension
{
    public static Vector2 Clamp(this Vector2 position, Vector2 upLeftPosition, Vector2 bottomRightPosition)
    {
        float x = Mathf.Clamp(position.x, upLeftPosition.x, bottomRightPosition.x);
        float y = Mathf.Clamp(position.y, bottomRightPosition.y, upLeftPosition.y);

        return new Vector2(x, y);
    }
}
