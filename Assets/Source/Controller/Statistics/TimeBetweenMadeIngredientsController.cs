using UnityEngine;
using Zenject;

public class TimeBetweenMadeIngredientsController : MonoBehaviour
{
    private TickableController _tickableController;
    private TimeMadeIngredients _time;
    private Stopwatch _stopwatch;

    [Inject]
    private void Construct(TickableController tickableController, TimeMadeIngredients time)
    {
        _tickableController = tickableController;
        _time = time;
    }

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
