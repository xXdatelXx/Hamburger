using System.Collections.Generic;
using System;

// Нада шоб не могли добавить null
public abstract class IngredientCollection
{
    private List<Ingredient> _ingredients = new();
    public IReadOnlyList<Ingredient> Ingredients => _ingredients;
    public int IngredientCount => _ingredients.Count;

    public Ingredient this[int index] => _ingredients[index];

    public void Add(Ingredient ingredient)
    {
        if (Valid(ingredient))
            _ingredients.Add(ingredient);
    }

    public void Insert(int index, Ingredient ingredient)
    {
        if (Valid(ingredient))
            _ingredients.Insert(index, ingredient);
    }

    public void RemoveAll()
    {
        _ingredients = new List<Ingredient>();
    }

    public void Set(int id, Ingredient ingredient)
    {
        if (Valid(ingredient))
            _ingredients[id] = ingredient;
    }

    public Ingredient Find(Predicate<Ingredient> ingredient)
    {
        return _ingredients.Find(ingredient);
    }

    private bool Valid(Ingredient ingredient)
    {
        if (ingredient is null)
            throw new NullReferenceException("ingredient on add == null");

        return true;
    }
}
