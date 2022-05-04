using UnityEngine;
using Zenject;

public class TimmerController : MonoBehaviour
{
    [Inject] private TickableController _tickableController;
    [Inject] private Timer _timer;
    [Inject] private TimerBalance _balance;
    private float _addTime;
    private float _removeTime;

    private void Awake()
    {
        _addTime = _balance.HamburgerAddTime;
        _removeTime = _balance.ErrorRemoveTime;

        _tickableController.Add(_timer);
    }

    public void Stop()
    {
        _timer.Stop();
    }

    public void Play()
    {
        _timer.Play();
    }

    public void AddTime()
    {
        _timer.AddTime(_addTime);
    }

    public void RemoveTime()
    {
        _timer.RemoveTime(_removeTime);
    }
}
