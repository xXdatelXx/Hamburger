using UnityEngine;
using Zenject;

public class TimePlayController : MonoBehaviour
{
    private TickableController _tickableController;
    private TimePlay _timePlay;
    private Stopwatch _stopwatch;
    private GameState _state;

    [Inject]
    private void Construct(TickableController tickableController, TimePlay timePlay, GameState state)
    {
        _tickableController = tickableController;
        _timePlay = timePlay;
        _stopwatch = new Stopwatch();
        _state = state;
    }

    private void Awake()
    {
        _tickableController.Add(_stopwatch);
        _stopwatch.Play();
        _timePlay.StartPlay(_stopwatch);
    }

    private void OnEnable()
    {
        _state.OnSetState += Stop;
    }

    private void OnDisable()
    {
        _state.OnSetState -= Stop;
    }

    private void Update()
    {
        _timePlay.Tick();
    }

    private void Stop(GameState.States state)
    {
        if (state == GameState.States.Lose)
            _timePlay.EndPlay();
    }
}
