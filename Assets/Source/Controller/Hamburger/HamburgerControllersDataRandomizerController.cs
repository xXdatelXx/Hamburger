using UnityEngine;
using Random = UnityEngine.Random;
using Zenject;
using System;

public class HamburgerControllersDataRandomizerController : MonoBehaviour
{
    private HideIngredientsBalance _hideBalance;
    private EventBalance _eventBalance;
    private HamburgerControllersDataRandomizer _data;
    private GameLevel _level;

    [Inject]
    private void Construct(HamburgerControllersDataRandomizer data, GameLevel level, EventBalance eventBalance, HideIngredientsBalance hideBalance)
    {
        _data = data;
        _level = level;
        _hideBalance = hideBalance;
        _eventBalance = eventBalance;
    }

    public void RandomizeIngredient()
    {
        int randomPair = _level.GetGameLevel() switch
        {
            Level.First => _eventBalance.RandomPairInLevel1,
            Level.Second => _eventBalance.RandomPairInLevel2,
            Level.Third => _eventBalance.RandomPairInLevel3,
            Level.Fourth => _eventBalance.RandomPairInLevel4,
            Level.Max => _eventBalance.RandomPairInLevelMax,
            _ => throw new InvalidOperationException()
        };

        _data.RandomizeIngredient(randomPair);
    }

    public void RandomizeHideId()
    {
        int hidesIngredient = _level.GetGameLevel() switch
        {
            Level.First => _hideBalance.HideIngredientsInLevel1,
            Level.Second => _hideBalance.HideIngredientsInLevel2,
            Level.Third => _hideBalance.HideIngredientsInLevel3,
            Level.Fourth => _hideBalance.HideIngredientsInLevel4,
            Level.Max => _hideBalance.HideIngredientsInLevelMax,
            _ => throw new InvalidOperationException()
        };

        // 0% - 100%
        bool hide = Random.Range(0, 100) < _hideBalance.PercentToHide;

        if (hide)
            _data.RandomizeHidesId(hidesIngredient);
    }
}
