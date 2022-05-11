using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HamburgerCompositeRoot : CompositeRoot
{
    [SerializeField] private List<HamburgerController> _controllers;
    [SerializeField] private List<HamburgerControllerImage> _images;
    [Inject] private ItemsList _items;
    [Inject] private ItemImages _itemImages;
    private List<(HamburgerController, HamburgerControllerImage)> _containers;
    private List<(Item, Sprite)> _containersData;

    public override void Compose()
    {
        _containers = new List<(HamburgerController, HamburgerControllerImage)>();
        _containersData = new List<(Item, Sprite)>();
        
        for (int i = 0; i < _controllers.Count; i++)
            _containers.Add((_controllers[i], _images[i]));
        for (int i = 0; i < _items.GetList().Count; i++)
            _containersData.Add((_items.GetList()[i] , _itemImages.Sprites[i]));

        Validate();
        ItemInit();
    }

    private void Validate()
    {
        var validation = new HamburgerCompositeRootValidation(_containers, _items.GetList());
        if (!validation.Validate())
            enabled = false;
    }

    public void ItemInit()
    {
        for (int i = 0; i < _controllers.Count; i++)
        {
            _containers[i].Item1.InIt(_containersData[i].Item1);
            _containers[i].Item2.Set(_containersData[i].Item2);
        }
    }

    public void RandomizeItems(int randomPairCount)
    {
        if (randomPairCount < 0)
            return;

        if (randomPairCount * 2 > _controllers.Count)
            return;

        var itemsId = new List<int>();
        for (int i = 0; i < randomPairCount * 2; i++)
        {
            int id = Random.Range(0, _items.GetList().Count);

            while (itemsId.Contains(id))
                id = Random.Range(0, _items.GetList().Count);

            itemsId.Add(id);
        }
        
        foreach (int id in itemsId)
            (_containersData[id], _containersData[itemsId[^1]]) = (_containersData[itemsId[^1]], _containersData[id]);
    }

    public void ItemInit(List<(HamburgerController, HamburgerControllerImage)> containers)
    {
        if (containers == null)
            throw new System.NullReferenceException("container in itemInit == null");

        int containerLength = (containers.Count < _containers.Count) ? containers.Count : _containers.Count;

        for (int i = 0; i < containerLength; i++)
        {
            containers[i].Item1.InIt(_containersData[i].Item1);
            containers[i].Item2.Set(_containersData[i].Item2);
        }
    }

    public void SetRecipe(Recipe recipe)
    {
        if (recipe is null)
        {
            enabled = false;
            throw new System.NullReferenceException("recipe on SetRecipe is null");
        }

        foreach (var controller in _controllers)
            controller.SetRecipe(recipe);
    }
}
