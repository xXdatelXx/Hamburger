using UnityEngine;
using Zenject;

public class TimePlayController : MonoBehaviour
{
    [Inject] private TickableController _tickableController;
    [Inject] private TimePlay _timePlay;
    private Stopwatch _stopwatch;

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
