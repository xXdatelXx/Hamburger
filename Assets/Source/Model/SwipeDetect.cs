using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class SwipeDetect : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField, Range(0, 100)] private float _minSwipeLength;
    private bool _canDetect => _minSwipeLength < Length;
    private Vector2 _startPosition;
    public float Length { get; private set; }
    public event Action<PointerEventData> OnBeginSwipe;
    public event Action<Direction> OnSwipe;
    public event Action<PointerEventData> OnSwiping;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = eventData.position;
        OnBeginSwipe?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnSwiping?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Length = Vector3.Magnitude(_startPosition - eventData.position);

        if (_canDetect)
            Detect(eventData);
    }

    private void Detect(PointerEventData eventData)
    {
        Vector2 vectorDirection = _startPosition - eventData.position;
        Direction direction =
            MathF.Abs(vectorDirection.x) > MathF.Abs(vectorDirection.y)
            ? vectorDirection.x > 0 ? Direction.Right : Direction.Left
            : vectorDirection.y > 0 ? Direction.Up : Direction.Down;

        OnSwipe?.Invoke(direction);
    }
}
