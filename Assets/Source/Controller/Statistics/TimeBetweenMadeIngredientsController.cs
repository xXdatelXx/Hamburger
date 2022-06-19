using UnityEngine;
using Zenject;

public class TimeBetweenMadeIngredientsController : MonoBehaviour
{
    [SerializeField] private GameState.States _playState;
    [SerializeField] private GameState.States _stopState;
    [SerializeField] private GameState.States _loseState;
    private TickableController _tickableController;
    private TimeMadeIngredients _time;
    private Stopwatch _stopwatch;
    private GameState _gameState;

    [Inject]
    private void Construct(TickableController tickableController, TimeMadeIngredients time, GameState state)
    {
        _tickableController = tickableController;
        _time = time;
        _gameState = state;
    }

    private void Awake()
    {
        _stopwatch = new Stopwatch();
        _time.SetStopwatch(_stopwatch);
        _tickableController.Add(_stopwatch);
    }

    private void OnEnable()
    {
        _gameState.OnSetState += Play;
        _gameState.OnSetState += Stop;
        _gameState.OnSetState += End;
    }

    private void OnDisable()
    {
        _gameState.OnSetState -= Play;
        _gameState.OnSetState -= Stop;
        _gameState.OnSetState -= End;
    }

    private void Play(GameState.States state)
    {
        if (state == _playState)
            _time.Play();
    }

    private void Stop(GameState.States state)
    {
        if (state == _stopState)
            _time.Stop();
    }

    private void End(GameState.States state)
    {
        if (state == _loseState)
            _time.End();
    }

    public void Tick()
    {
        _time.Tick();
    }
}
