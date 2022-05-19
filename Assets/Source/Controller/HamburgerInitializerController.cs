using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Zenject;
using System;

public class HamburgerInitializerController : MonoBehaviour
{
    [SerializeField] private List<HamburgerController> _controllers;
    [SerializeField] private List<HamburgerControllerImage> _images;
    private HamburgerControllersInitializer _initializer;

    [Inject]
    private void Construct(HamburgerControllersInitializerFactory factory, EventBalance balance, GameLevel level)
    {
        if (_controllers.Count != _images.Count)
        {
            enabled = false;
            throw new IndexOutOfRangeException("controllers.Count != images.Count");
        }

        _initializer = factory.Create(_controllers.Select((t, i) => (t, _images[i])).ToList());
    }

    public void Init()
    {
        _initializer.Init();
    }

    public void SetRecipe(Recipe recipe)
    {
        _initializer.SetRecipe(recipe);
    }
}
