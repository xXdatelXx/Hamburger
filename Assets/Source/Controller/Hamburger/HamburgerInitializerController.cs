using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Zenject;
using System;

public class HamburgerInitializerController : MonoBehaviour
{
    [SerializeField] private List<HamburgerController> _controllers;
    [SerializeField] private List<HamburgerControllerImage> _images;
    [SerializeField] private GameState.States[] _initStates;
    private HamburgerControllersInitializer _initializer;
    private GameState _gameState;

    [Inject]
    private void Construct(HamburgerControllersInitializerFactory factory, EventBalance balance, GameLevel level, GameState state)
    {
        if (_controllers.Count != _images.Count)
        {
            enabled = false;
            throw new IndexOutOfRangeException("controllers.Count != images.Count");
        }

        _initializer = factory.Create(_controllers.Select((t, i) => (t, _images[i])).ToList());
        _gameState = state;
    }

    private void OnEnable()
    {
        _gameState.OnSetState += Init;
    }

    private void OnDisable()
    {
        _gameState.OnSetState -= Init;
    }

    private void Init(GameState.States state)
    {
        foreach (var item in _initStates)
            if (item == state)
                _initializer.Init();
    }

    public void SetRecipe(Recipe recipe)
    {
        _initializer.SetRecipe(recipe);
    }
}
