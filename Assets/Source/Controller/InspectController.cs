using UnityEngine;
using Zenject;

public class InspectController : MonoBehaviour
{
    [Inject] private GameState _gameState;
    [Inject] private EventBalance _balance;
    [Inject] private Score _score;

    public void Inspect()
    {
        if (_score.CurentScore % _balance.HamburgerToEvent == 0)
        {
            _gameState.InspectEvent();
            return;
        }

        _gameState.InspectRecipe();
    }
}
