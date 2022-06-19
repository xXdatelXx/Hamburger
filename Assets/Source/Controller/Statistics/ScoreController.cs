using UnityEngine;
using Zenject;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private GameState.States _increaseState;
    [Inject] private GameState _gameState;
    [Inject] private Score _score;

    private void OnEnable()
    {
        _gameState.OnSetState += IncreaseScore;
    }

    private void OnDisable()
    {
        _gameState.OnSetState -= IncreaseScore;
    }

    private void IncreaseScore(GameState.States state)
    {
        if (state == _increaseState)
            _score.IncreaseScore();
    }
}
