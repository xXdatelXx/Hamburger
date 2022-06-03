using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class KursorMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SwipeDetect _swipeDetect;
    [SerializeField] private Vector2 _upLeftPosition;
    [SerializeField] private Vector2 _bottomRightPosition;
    private Vector3 _startPosition;

    private void Awake()
    {
        try
        {
            if (_camera == null)
                throw new NullReferenceException(nameof(_camera));
            if (_swipeDetect == null)
                throw new NullReferenceException(nameof(_swipeDetect));
        }
        catch (Exception e)
        {
            enabled = false;
            Debug.LogError(e);
        }
    }

    private void OnEnable()
    {
        _swipeDetect.OnBeginSwipe += SetStartPosition;
        _swipeDetect.OnSwiping += Move;
    }

    private void OnDisable()
    {
        _swipeDetect.OnBeginSwipe -= SetStartPosition;
        _swipeDetect.OnSwiping -= Move;
    }

    private void SetStartPosition(PointerEventData eventData)
    {
        _startPosition = transform.position - _camera.ScreenToWorldPoint(eventData.position);
    }

    private void Move(PointerEventData eventData)
    {
        transform.position =
            (_camera.ScreenToWorldPoint(eventData.position) + _startPosition)
            .Clamp(_upLeftPosition, _bottomRightPosition);
    }
}