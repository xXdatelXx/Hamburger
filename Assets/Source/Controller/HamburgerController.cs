using System;
using UnityEngine;
using Zenject;

public class HamburgerController : MonoBehaviour
{
    private Item _item;

    [Inject] private readonly Hamburger _hamburger;
    [Inject] private readonly HamburgerFactory _itemFactory;
    [Inject] private readonly HamburgerControllersEvents _events;
    [Inject] private HamburgerValid _valid;

    private bool _initialized => _item != null && _hamburger != null && _itemFactory != null;
    private bool _canAdd => _valid.ValidItem(_item, _hamburger.ItemCount);
    private bool _finish => _valid.Finish(_hamburger);

    public void InIt(Item item)
    {
        if (item == null)
        {
            enabled = false;
            throw new NullReferenceException("item == null");
        }

        _item = item;
    }

    public void TryAdd()
    {
        if (!_initialized)
            return;

        if (_canAdd)
        {
            _hamburger.Add(_itemFactory.Create(_item));
            _events.Add();
        }
        else
        {
            _events.Error();
        }

        if (_finish)
        {
            _events.Finish();
            _hamburger.RemoveAll();
        }
    }

    public void SetRecipe(Recipe recipe)
    {
        _valid = new HamburgerValid(recipe);
    }
}
