using UnityEngine;
using Zenject;

public class TimeBetweenMadeItemsController : MonoBehaviour
{
    [Inject] private TickableController _tickableController;
    [Inject] private TimeMadeItems _time;
    private Stopwatch _stopwatch;

    private void Awake()
    {
        _stopwatch = new Stopwatch();
        _time.SetStopwatch(_stopwatch);
        _tickableController.Add(_stopwatch);
    }

    public void Play()
    {
        _time.Play();
    }

    public void Tick()
    {
        _time.Tick();
    }

    public void Stop()
    {
        _time.Stop();
    }

    public void End()
    {
        _time.End();
    }
}
