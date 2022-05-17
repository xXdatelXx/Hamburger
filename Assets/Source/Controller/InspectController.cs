using UnityEngine;
using Zenject;

public class InspectController : MonoBehaviour
{
    private GameState _gameState;
    private EventBalance _balance;
    private Score _score;

    [Inject]
    private void Construct(GameState gameState, EventBalance balance, Score score)
    {
        _gameState = gameState;
        _balance = balance;
        _score = score;
    }

    public void Inspect()
    {
        if (_score.CurentScore % _balance.HamburgersToEvent == 0)
        {
            _gameState.InspectEvent();
            return;
        }

        _gameState.InspectRecipe();
    }
}
