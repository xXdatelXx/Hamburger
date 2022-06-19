using UnityEngine;
using Zenject;

public class TimeOutView : MonoBehaviour
{
    [Inject] private Timer _timer;
    [Inject] private GameState _gameState;

    private void OnEnable()
    {
        _timer.OnEnd += () => _gameState.Lose();
    }

    private void OnDisable()
    {
        _timer.OnEnd -= () => _gameState.Lose();
    }
}
