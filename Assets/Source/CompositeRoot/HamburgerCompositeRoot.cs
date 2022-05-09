using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HamburgerCompositeRoot : CompositeRoot
{
    [SerializeField] private List<HamburgerController> _controllers;
    [SerializeField] private List<HamburgerControllerImage> _images;
    [Inject] private ItemsList _items;
    [Inject] private ItemImages _itemImages;
    private List<(HamburgerController, HamburgerControllerImage)> _container;

    public override void Compose()
    {
        _container = new List<(HamburgerController, HamburgerControllerImage)>();
        for (int i = 0; i < _controllers.Count; i++)
            _container.Add((_controllers[i], _images[i]));

        Validate();
        ItemInit();
    }

    private void Validate()
    {
        var validation = new HamburgerCompositeRootValidation(_container, _items.GetList());
        if (!validation.Validate())
            enabled = false;
    }

    private void ItemInit()
    {
        for (int i = 0; i < _controllers.Count; i++)
        {
            _container[i].Item1.InIt(_items.GetList()[i]);
            _container[i].Item2.Set(_itemImages.Sprites[i]);
        }
    }

    public void RandomItemInit(int randomPairCount)
    {
        if (randomPairCount < 0)
            return;

        if (randomPairCount * 2 > _controllers.Count)
            return;

        var itemsId = new List<int>();
        for (int i = 0; i < randomPairCount * 2; i++)
        {
            int id = Random.Range(0, _controllers.Count);

            while (itemsId.Contains(id))
                id = Random.Range(0, _controllers.Count);

            itemsId.Add(id);
        }

        foreach (var id in itemsId)
        {
            var temp = _container[id];
            _container[id] = _container[itemsId[itemsId.Count - 1]];
            _container[itemsId[itemsId.Count - 1]] = temp;
        }

        ItemInit();
    }

    public void SetRecipe(Recipe recipe)
    {
        if (recipe is null)
        {
            enabled = false;
            throw new System.NullReferenceException("recipe on SetRecipe is null");
        }

        for (int i = 0; i < _controllers.Count; i++)
            _controllers[i].SetRecipe(recipe);
    }
}
