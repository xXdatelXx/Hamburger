using UnityEngine;
using Zenject;

public class TimeOutView : MonoBehaviour
{
    [Inject] private Timer _timer;
    [Inject] private GameState _gameState;

    private void Awake()
    {
        _timer.OnEnd += () => _gameState.Lose();
    }
}
