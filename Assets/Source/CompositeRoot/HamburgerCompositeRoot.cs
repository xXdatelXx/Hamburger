using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class HamburgerCompositeRoot : CompositeRoot
{
    [SerializeField] private List<HamburgerController> _controllers;
    [SerializeField] private List<HamburgerControllerImage> _images;
    [Inject] private ItemsList _items;
    [Inject] private ItemImages _itemImages;

    public override void Compose()
    {
        Validate();
        StandartItemInit();
    }

    private void Validate()
    {
        var validation = new HamburgerCompositeRootValidation(_controllers, _items.GetList());
        if (!validation.Validate())
            enabled = false;
    }

    private void StandartItemInit()
    {
        for (int i = 0; i < _controllers.Count; i++)
            _controllers[i].InIt(_items.GetList()[i]);

        for (int i = 0; i < _itemImages.Count; i++)
            _images[i].Set(_itemImages.Sprites[i]);
    }

    public void SetRecipe(Recipe recipe)
    {
        if (recipe is null)
        {
            enabled = false;
            throw new NullReferenceException("recipe on setRecipe is null");
        }

        for (int i = 0; i < _controllers.Count; i++)
            _controllers[i].SetRecipe(recipe);
    }
}
