using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Zenject;

public class EventView : MonoBehaviour
{
    [SerializeField] private List<HamburgerController> _controllers;
    [SerializeField] private List<HamburgerControllerImage> _images;
    [Inject] private HamburgerCompositeRoot _hamburgerCompositeRoot;
    private List<(HamburgerController, HamburgerControllerImage)> _containers;

    private void Awake()
    {
        if (_controllers.Count != _images.Count)
        {
            enabled = false;
            throw new IndexOutOfRangeException("controllers.Count != images.Count");
        }

        _containers = _controllers.Select((t, i) => (t, _images[i])).ToList();
    }

    public void View()
    {
        _hamburgerCompositeRoot.ItemInit(_containers);
    }
}
