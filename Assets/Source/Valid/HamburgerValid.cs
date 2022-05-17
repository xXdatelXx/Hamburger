using System;

public class HamburgerValid
{
    private readonly Recipe _recipe;
    private readonly IngredientCollectionValidation _ingredientCollectionValidation;

    public HamburgerValid(Recipe recipe)
    {
        if (recipe == null)
            throw new ArgumentNullException("recipe on hamburgerValid == null");

        _recipe = recipe;
        _ingredientCollectionValidation = new IngredientCollectionValidation();
    }

    public bool ValidItem(Ingredient ingredient, int number)
    {
        if (number < 0)
            return false;

        if (ingredient == null)
            return false;

        return _recipe[number].GetType() == ingredient.GetType();
    }

    public bool Finish(Hamburger hamburger)
    {
        return _ingredientCollectionValidation.Equal(hamburger, _recipe);
    }
}
