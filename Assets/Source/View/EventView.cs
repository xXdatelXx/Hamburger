using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Zenject;

public class EventView : MonoBehaviour
{
    [SerializeField] private List<HamburgerController> _controllers;
    [SerializeField] private List<HamburgerControllerImage> _images;
    private HamburgerControllersInitializer _initializer;
    private List<(HamburgerController, HamburgerControllerImage)> _containers;

    [Inject]
    private void Construct(HamburgerControllersInitializer factory)
    {
        if (_controllers.Count != _images.Count)
        {
            enabled = false;
            throw new IndexOutOfRangeException("controllers.Count != images.Count");
        }

        _containers = _controllers.Select((t, i) => (t, _images[i])).ToList();

        _initializer = factory.Create(_containers);
    }

    public void View()
    {
        _initializer.IngredientInit();
    }
}
