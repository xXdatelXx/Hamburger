using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class SwipeDetect : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField, Range(0, 100)] private float _minSwipeLength;
    public event Action<Direction> OnSwipe;
    public event Action OnSwiping;
    private bool _canDetect => _minSwipeLength < _length;
    private Vector2 _startPosition;
    private float _length;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnSwiping?.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _length = Vector3.Magnitude(_startPosition - eventData.position);

        if (_canDetect)
            Detect(eventData);
    }

    private void Detect(PointerEventData eventData)
    {
        Vector2 vectorDirection = _startPosition - eventData.position;
        Direction direction =
            MathF.Abs(vectorDirection.x) > MathF.Abs(vectorDirection.y)
            ? vectorDirection.x > 0 ? Direction.Left : Direction.Right
            : vectorDirection.y > 0 ? Direction.Up : Direction.Down;

        OnSwipe?.Invoke(direction);
    }
}
