using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Zenject;
using System;

public class HamburgerInitialxizerController : MonoBehaviour
{
    [SerializeField] private List<HamburgerController> _controllers;
    [SerializeField] private List<HamburgerControllerImage> _images;
    private HamburgerControllersInitializer _initializer;
    private EventBalance _balance;
    private GameLevel _level;

    [Inject]
    private void Construct(HamburgerControllersInitializer hamburgerControllersInitializer, EventBalance balance, GameLevel level)
    {
        if (_controllers.Count != _images.Count)
        {
            enabled = false;
            throw new IndexOutOfRangeException("controllers.Count != images.Count");
        }

        _initializer = hamburgerControllersInitializer;
        _balance = balance;
        _level = level;
        
        Init();
    }

    public void Init()
    {
        _initializer.Init(_controllers.Select((t, i) => (t, _images[i])).ToList());
    }

    public void RandomInit()
    {
        int randomPair = _level.GetGameLevel() switch
        {
            Level.First => _balance.RandomPairInLevel1,
            Level.Second => _balance.RandomPairInLevel2,
            Level.Third => _balance.RandomPairInLevel3,
            Level.Fourth => _balance.RandomPairInLevel4,
            Level.Max => _balance.RandomPairInLevelMax,
            _ => throw new InvalidOperationException()
        };

        _initializer.RandomizeIngredient(randomPair);
    }
}
