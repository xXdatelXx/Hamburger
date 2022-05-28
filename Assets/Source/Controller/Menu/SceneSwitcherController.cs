using System;
using System.Collections;
using UnityEngine;

public class SceneSwitcherController : MonoBehaviour
{
    [SerializeField] private SwipeDetect _swipeDetect;
    [SerializeField] private SceneSwitcherAnimator _switcherAnimator;
    [SerializeField, Range(0, 10)] private float _timeToLoad;
    [SerializeField] private bool _canSwitchLeft;
    [SerializeField] private bool _canSwitchRight;
    private SceneSwitcher _sceneSwitcher;

    private void Awake()
    {
        _sceneSwitcher = new SceneSwitcher();
    }

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
        switch (direction)
        {
            case Direction.Left:
                _switcherAnimator.SwitchLeft();
                break;
            case Direction.Right:
                _switcherAnimator.SwitchRight();
                break;
            default:
                return;
        }

        StartCoroutine(Load(direction));
    }

    private IEnumerator Load(Direction direction)
    {
        yield return new WaitForSeconds(_timeToLoad);
        _sceneSwitcher.Switch(direction);
    }
}
