using UnityEngine;

public abstract class Ingredient : MonoBehaviour
{
    [SerializeField] private Transform _downPosition;
    [SerializeField] private Transform _upPosition;
    [SerializeField] private SpriteRenderer _sprite;

    public Vector2 DownLocalPosition => _downPosition.localPosition;
    public Vector2 UpPosition => _upPosition.position;

    private void Awake()
    {
        if (_downPosition == null || _upPosition == null)
        {
            _downPosition = transform;
            _upPosition = transform;
        }
    }

    public virtual void SetLayer(int layer)
    {
        _sprite.sortingOrder = layer;
    }
}
