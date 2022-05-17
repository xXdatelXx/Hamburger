using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipeFactory
{
    private readonly List<Ingredient> _ingredients;
    private readonly GameLevel _gameLevel;
    private readonly IngredientsInLevelBalance _balance;
    private readonly IngredientCollectionValidation _ingredientCollectionValidation;
    public Recipe Recipe { get; private set; }

    public RecipeFactory(Ingredients ingredients, IngredientsInLevelBalance balance, GameLevel gameLevel)
    {
        _gameLevel = gameLevel;
        _balance = balance;
        _ingredientCollectionValidation = new IngredientCollectionValidation();

        _ingredients = ingredients.GetList()
             .Where
            (
                ingredient =>
                ingredient.GetType() != typeof(BreadTop) &&
                ingredient.GetType() != typeof(BreadTop)
            )
            .ToList();
    }

    public Recipe Create()
    {
        var recipe = new Recipe();

        recipe.Add(new BreadBottom());

        int itemsCount = GetItemsCount();
        for (int i = 0; i < itemsCount; i++)
        {
            int nextItemId = Random.Range(0, _ingredients.Count);

            while (_ingredients[nextItemId].GetType() == recipe[i].GetType())
                nextItemId = Random.Range(0, _ingredients.Count);

            recipe.Add(_ingredients[nextItemId]);
        }

        TryRemoveGreen(ref recipe);
        TryAddMeat(ref recipe);

        recipe.Add(new BreadTop());

        if (_ingredientCollectionValidation.Equal(recipe, Recipe))
            return Recipe = Create();

        return Recipe = recipe;
    }

    private void TryAddMeat(ref Recipe recipe)
    {
        // якшо немае мяса то додать
        Ingredient meatIngredient = recipe.Find(item => item.GetType() == typeof(Meat));

        if (meatIngredient is null)
            recipe.Insert(Random.Range(1, recipe.IngredientCount), new Meat());
    }

    private void TryRemoveGreen(ref Recipe recipe)
    {
        // якшо э зелень и пид нею э сир - зелень заменити на шось инше
        List<int> greensId = new List<int>();
        for (int i = 0; i < recipe.IngredientCount; i++)
        {
            if (recipe[i].GetType() == typeof(Green))
                greensId.Add(i);
        }

        // Вибрати з всих елементив все крим сира и зелени
        // сир и зелень не нада шоб не було повторок
        List<Ingredient> ingredients = _ingredients
            .Where
            (
                item =>
                item.GetType() != typeof(Chease) &&
                item.GetType() != typeof(Green)
            )
            .ToList();

        for (int i = 0; i < greensId.Count; i++)
        {
            if (recipe[greensId[i] - 1].GetType() == typeof(Chease))
                recipe.Set(greensId[i], ingredients[Random.Range(0, ingredients.Count)]);
        }
    }

    private int GetItemsCount()
    {
        Level level = _gameLevel.GetGameLevel();

        if (level == Level.First)
            return Random.Range(_balance.IngredientsInFirstLevel.Item1, _balance.IngredientsInFirstLevel.Item2);
        if (level == Level.Second)
            return Random.Range(_balance.IngredientsInSecondLevel.Item1, _balance.IngredientsInSecondLevel.Item2);
        if (level == Level.Third)
            return Random.Range(_balance.IngredientsInThirdLevel.Item1, _balance.IngredientsInThirdLevel.Item2);
        if (level == Level.Fourth)
            return Random.Range(_balance.IngredientsInFourthtLevel.Item1, _balance.IngredientsInFourthtLevel.Item2);

        return Random.Range(_balance.IngredientsInMaxLevel.Item1, _balance.IngredientsInMaxLevel.Item2);
    }
}
