using UnityEngine;

public class SceneSwitcherSwipeController : MonoBehaviour
{
    [SerializeField] private SwipeDetect _swipeDetect;
    [SerializeField] private bool _canSwitchLeft;
    [SerializeField] private bool _canSwitchRight;
    [SerializeField] private int _leftScene;
    [SerializeField] private int _rightScene;
    [SerializeField] private SceneSwitcher _sceneSwitcher;

    private void OnEnable()
    {
        _swipeDetect.OnSwipe += Switch;
    }

    private void OnDisable()
    {
        _swipeDetect.OnSwipe -= Switch;
    }

    private void Switch(Direction direction)
    {
        if (direction == Direction.Left && _canSwitchLeft)
            _sceneSwitcher.AsyncLoad(_leftScene);
        if (direction == Direction.Right && _canSwitchRight)
            _sceneSwitcher.AsyncLoad(_rightScene);
    }
}
