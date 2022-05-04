using System.Collections.Generic;
using UnityEngine;
using System;

public class HamburgerCompositeRootValidation : MonoBehaviour
{
    private List<HamburgerController> _controllers;
    private List<Item> _items;

    public HamburgerCompositeRootValidation(List<HamburgerController> controllers, List<Item> items)
    {
        _controllers = controllers;
        _items = items;
    }

    public bool Validate()
    {
        if (_controllers == null)
        {
            return false;
            throw new NullReferenceException("Сontroller == null");
        }

        if (_items == null)
        {
            return false;
            throw new NullReferenceException("Items == null");
        }

        if (_controllers.Count != _items.Count)
        {
            return false;
            throw new NullReferenceException("Сontrollers Count != Items Count");
        }

        return true;
    }
}
