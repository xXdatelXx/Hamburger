using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class СursorMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SwipeDetect _swipeDetect;
    [SerializeField] private Vector2 _upLeftPosition;
    [SerializeField] private Vector2 _bottomRightPosition;
    [SerializeField, Range(0, 1)] private float _inertionSpeed;
    [SerializeField, Range(0, 1)] private float _inertionForce;
    private Vector3 _startPosition;
    private Vector3 _target;

    private void Awake()
    {
        _target = transform.position;
        Validate();
    }

    private void OnEnable()
    {
        _swipeDetect.OnBeginSwipe += SetStartPosition;
        _swipeDetect.OnSwiping += Move;
        _swipeDetect.OnSwipe += SetTarget;
    }

    private void OnDisable()
    {
        _swipeDetect.OnBeginSwipe -= SetStartPosition;
        _swipeDetect.OnSwiping -= Move;
        _swipeDetect.OnSwipe -= SetTarget;
    }

    private void FixedUpdate()
    {
        Inert();
    }

    private void SetStartPosition(PointerEventData eventData)
    {
        _startPosition = transform.position - _camera.ScreenToWorldPoint(eventData.position);
    }

    private void Move(PointerEventData eventData)
    {
        transform.position = _camera.ScreenToWorldPoint(eventData.position) + _startPosition;

        ClampPosition();
        _target = transform.position;
    }

    private void SetTarget(Direction direction)
    {
        Vector3 increment =
            (direction == Direction.Down) ? Vector3.up :
            (direction == Direction.Up) ? Vector3.down :
            (direction == Direction.Left) ? Vector3.right :
            (direction == Direction.Right) ? Vector3.left :
            throw new InvalidOperationException();

        _target = transform.position + increment * _swipeDetect.Length * _inertionForce;
    }

    private void Inert()
    {
        transform.position = Vector3.Lerp(transform.position, _target, _inertionSpeed);
        ClampPosition();
    }

    private void ClampPosition()
    {
        transform.position = transform.position.Clamp(_upLeftPosition, _bottomRightPosition);
    }

    private void Validate()
    {
        if (_camera == null)
            throw new NullReferenceException(nameof(_camera));
        if (_swipeDetect == null)
            throw new NullReferenceException(nameof(_swipeDetect));
    }
}