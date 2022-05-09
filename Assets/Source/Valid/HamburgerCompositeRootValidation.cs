using System.Collections.Generic;
using UnityEngine;
using System;

public class HamburgerCompositeRootValidation
{
    private List<(HamburgerController, HamburgerControllerImage)> _container;
    private List<Item> _items;

    public HamburgerCompositeRootValidation(List<(HamburgerController, HamburgerControllerImage)> container, List<Item> items)
    {
        _container = container;
        _items = items;
    }

    public bool Validate()
    {
        if (_container == null)
        {
            return false;
            throw new NullReferenceException("Сontroller == null");
        }

        if (_items == null)
        {
            return false;
            throw new NullReferenceException("Items == null");
        }

        if (_container.Count != _items.Count)
        {
            return false;
            throw new NullReferenceException("Сontrollers Count != Items Count");
        }

        return true;
    }
}
