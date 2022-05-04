using System;

public class HamburgerValid
{
    private readonly Recipe _recipe;
    private readonly ItemsCollectionValidation _itemsCollectionValidation;

    public HamburgerValid(Recipe recipe)
    {
        if (recipe == null)
            throw new ArgumentNullException("recipe on hamburgerValid == null");

        _recipe = recipe;
        _itemsCollectionValidation = new ItemsCollectionValidation();
    }

    public bool ValidItem(Item item, int number)
    {
        if (number < 0)
            return false;

        if (item == null)
            return false;

        return _recipe[number].GetType() == item.GetType();
    }

    public bool Finish(Hamburger hamburger)
    {
        return _itemsCollectionValidation.Equal(hamburger, _recipe);
    }
}
