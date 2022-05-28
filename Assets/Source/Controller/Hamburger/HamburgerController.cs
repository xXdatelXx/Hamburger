using System;
using UnityEngine;
using Zenject;

public class HamburgerController : MonoBehaviour
{
    private Ingredient _ingredient;

    private Hamburger _hamburger;
    private HamburgerFactory _factory;
    private HamburgerControllersEvents _events;
    private HamburgerValid _valid;

    private bool _canAdd => _valid.ValidItem(_ingredient, _hamburger.IngredientCount);
    private bool _finish => _valid.Finish(_hamburger);

    [Inject]
    private void Construct(Hamburger hamburger, HamburgerFactory factory, HamburgerControllersEvents events, HamburgerValid valid)
    {
        _hamburger = hamburger;
        _factory = factory;
        _events = events;
        _valid = valid;
    }

    public void SetIngredient(Ingredient ingredient)
    {
        if (ingredient == null)
        {
            enabled = false;
            throw new NullReferenceException("ingredient == null");
        }

        _ingredient = ingredient;
    }

    public void TryAdd()
    {
        if (_ingredient is null)
            return;

        if (_canAdd)
        {
            _hamburger.Add(_factory.Create(_ingredient));
            _events.Add();

            if (_finish)
            {
                _events.Finish();
                _hamburger.RemoveAll();
            }

            return;
        }

        _events.Error();
    }

    public void SetRecipe(Recipe recipe)
    {
        _valid = new HamburgerValid(recipe);
    }
}
