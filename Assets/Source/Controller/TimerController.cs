using UnityEngine;
using Zenject;

public class TimerController : MonoBehaviour
{
    private TickableController _tickableController;
    private Timer _timer;
    private TimerBalance _balance;
    private float _addTime;
    private float _removeTime;

    [Inject]
    private void Construct(TickableController tickableController, Timer timer, TimerBalance balance)
    {
        _tickableController = tickableController;
        _timer = timer;
        _balance = balance;
    }

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
