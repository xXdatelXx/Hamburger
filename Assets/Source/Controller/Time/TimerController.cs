using UnityEngine;
using Zenject;

public class TimerController : MonoBehaviour
{
    [SerializeField] private GameState.States _playState;
    [SerializeField] private GameState.States _addTimeState;
    [SerializeField] private GameState.States[] _stopStates;
    private GameState _gameState;
    private TickableController _tickableController;
    private Timer _timer;
    private TimerBalance _balance;
    private float _addTime;
    private float _removeTime;

    [Inject]
    private void Construct(TickableController tickableController, Timer timer, TimerBalance balance, GameState gameState)
    {
        _tickableController = tickableController;
        _timer = timer;
        _gameState = gameState;
        _balance = balance;

        _addTime = _balance.HamburgerAddTime;
        _removeTime = _balance.ErrorRemoveTime;

        _tickableController.Add(_timer);
    }

    private void OnEnable()
    {
        _gameState.OnSetState += HandleState;
    }

    private void OnDisable()
    {
        _gameState.OnSetState -= HandleState;
    }

    private void HandleState(GameState.States state)
    {
        if (_playState == state)
            Play();

        if (_addTimeState == state)
            AddTime();

        foreach (var i in _stopStates)
        {
            if (i == state)
                Stop();
        }
    }

    private void Stop()
    {
        _timer.Stop();
    }

    private void Play()
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
