using UnityEngine;
using System.Collections.Generic;
using Zenject;
using System;
using Random = UnityEngine.Random;

public class HamburgerControllersDataRandomizerController : MonoBehaviour
{
    [SerializeField] private GameState.States _randomizeState;
    private HideIngredientsBalance _hideBalance;
    private EventBalance _eventBalance;
    private HamburgerControllersDataRandomizer _data;
    private GameLevel _level;
    private GameState _gameState;

    [Inject]
    private void Construct(HamburgerControllersDataRandomizer data, GameLevel level, EventBalance eventBalance, HideIngredientsBalance hideBalance, GameState state)
    {
        _data = data;
        _level = level;
        _hideBalance = hideBalance;
        _eventBalance = eventBalance;
        _gameState = state;
    }

    private void OnEnable()
    {
        _gameState.OnSetState += TryRandomize;
    }

    private void OnDisable()
    {
        _gameState.OnSetState -= TryRandomize;
    }

    private void TryRandomize(GameState.States state)
    {
        if (_randomizeState == state)
        {
            RandomizeIngredient();
            RandomizeHideId();
        }
    }

    private void RandomizeIngredient()
    {
        int randomPair = EnumSelect(_eventBalance.List);

        _data.RandomizeIngredient(randomPair);
    }

    private void RandomizeHideId()
    {
        int hidesIngredient = EnumSelect(_hideBalance.List);

        // 0% - 100%
        bool hide = Random.Range(0, 100) < _hideBalance.PercentToHide;

        if (hide)
            _data.RandomizeHidesId(hidesIngredient);
    }

    private int EnumSelect(List<int> values)
    {
        for (int i = 0; i < Enum.GetNames(typeof(Level)).Length; i++)
            if ((int)_level.GetGameLevel() == i)
                return values[i];

        throw new InvalidOperationException();
    }
}
