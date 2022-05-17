using UnityEngine;
using Zenject;

public class TimePlayController : MonoBehaviour
{
    private TickableController _tickableController;
    private TimePlay _timePlay;
    private Stopwatch _stopwatch;

    [Inject]
    private void Construct(TickableController tickableController, TimePlay timePlay)
    {
        _tickableController = tickableController;
        _timePlay = timePlay;
    }

    private void Awake()
    {
        _stopwatch = new Stopwatch();
        _tickableController.Add(_stopwatch);
        _stopwatch.Play();
        _timePlay.StartPlay(_stopwatch);
    }

    public void Stop()
    {
        _timePlay.EndPlay();
    }
}
