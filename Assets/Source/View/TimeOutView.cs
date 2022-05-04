using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class TimeOutView : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnd;
    [Inject] private Timer _timer;

    private void Awake()
    {
        _timer.OnEnd += () => _onEnd?.Invoke();
    }
}
