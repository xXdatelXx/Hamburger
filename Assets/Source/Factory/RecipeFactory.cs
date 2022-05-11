using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipeFactory
{
    private readonly List<Item> _items;
    private readonly GameLevel _gameLevel;
    private readonly ItemsInLevelBalance _itemsInLevel;
    private readonly ItemsCollectionValidation _itemsCollectionValidation;
    public Recipe Recipe { get; private set; }

    public RecipeFactory(ItemsList itemList, ItemsInLevelBalance itemsInLevel, GameLevel gameLevel)
    {
        _gameLevel = gameLevel;
        _itemsInLevel = itemsInLevel;
        _itemsCollectionValidation = new ItemsCollectionValidation();

        _items = itemList.GetList()
             .Where
            (
                item =>
                item.GetType() != new BreadDownItem().GetType() &&
                item.GetType() != new BreadUpItem().GetType()
            )
            .ToList();
    }

    public Recipe Create()
    {
        var recipe = new Recipe();

        recipe.Add(new BreadDownItem());

        int itemsCount = GetItemsCount();
        for (int i = 0; i < itemsCount; i++)
        {
            int nextItemId = Random.Range(0, _items.Count);

            while (_items[nextItemId].GetType() == recipe[i].GetType())
                nextItemId = Random.Range(0, _items.Count);

            recipe.Add(_items[nextItemId]);
        }

        TryRemoveGreen(ref recipe);
        TryAddMeat(ref recipe);

        recipe.Add(new BreadUpItem());

        if (_itemsCollectionValidation.Equal(recipe, Recipe))
            return Recipe = Create();

        return Recipe = recipe;
    }

    private void TryAddMeat(ref Recipe recipe)
    {
        // якшо немае мяса то додать
        Item meatItem = recipe.Find(item => item.GetType() == new MeatItem().GetType());

        if (meatItem is null)
            recipe.Insert(Random.Range(1, recipe.ItemCount), new MeatItem());
    }

    private void TryRemoveGreen(ref Recipe recipe)
    {
        // якшо э зелень и пид нею э сир - зелень заменити на шось инше
        List<int> greensId = new List<int>();
        for (int i = 0; i < recipe.ItemCount; i++)
        {
            if (recipe[i].GetType() == new GreenItem().GetType())
                greensId.Add(i);
        }

        // Вибрати з всих елементив все крим сира и зелени
        // сир и зелень не нада шоб не було повторок
        List<Item> items = _items
            .Where
            (
                item =>
                item.GetType() != new CheaseItem().GetType() &&
                item.GetType() != new GreenItem().GetType()
            )
            .ToList();

        for (int i = 0; i < greensId.Count; i++)
        {
            if (recipe[greensId[i] - 1].GetType() == new CheaseItem().GetType())
                recipe.Set(greensId[i], items[Random.Range(0, items.Count)]);
        }
    }

    private int GetItemsCount()
    {
        Level level = _gameLevel.GetGameLevel();
        if (level == Level.First)
            return Random.Range(_itemsInLevel.ItemsInFirstLevel.Item1, _itemsInLevel.ItemsInFirstLevel.Item2);
        if (level == Level.Second)
            return Random.Range(_itemsInLevel.ItemsInSecondLevel.Item1, _itemsInLevel.ItemsInSecondLevel.Item2);
        if (level == Level.Third)
            return Random.Range(_itemsInLevel.ItemsInThirdLevel.Item1, _itemsInLevel.ItemsInThirdLevel.Item2);
        if (level == Level.Fourth)
            return Random.Range(_itemsInLevel.ItemsInFourthtLevel.Item1, _itemsInLevel.ItemsInFourthtLevel.Item2);

        return Random.Range(_itemsInLevel.ItemsInMaxLevel.Item1, _itemsInLevel.ItemsInMaxLevel.Item2);
    }
}
