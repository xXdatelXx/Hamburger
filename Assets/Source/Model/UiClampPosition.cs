using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UiClampPosition : MonoBehaviour
{
    [SerializeField] private Vector2 _leftTopPosition;
    [SerializeField] private Vector2 _rightBottomPosition;
    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Clamp();
    }

    private void Clamp()
    {
        _transform.anchoredPosition = _transform.anchoredPosition.Clamp(_leftTopPosition, _rightBottomPosition);
    }
}
