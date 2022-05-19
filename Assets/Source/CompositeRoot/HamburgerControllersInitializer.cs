using System.Collections.Generic;

public class HamburgerControllersInitializer
{
    private List<(HamburgerController, HamburgerControllerImage)> _containers;
    private HamburgerControllersData _data;

    public HamburgerControllersInitializer(HamburgerControllersData data, List<(HamburgerController, HamburgerControllerImage)> containers)
    {
        _data = data;
        _containers = containers;
    }

    public void Init()
    {
        for (int i = 0; i < _containers.Count; i++)
        {
            _containers[i].Item1.SetIngredient(_data.Containers[i].Item1);
            _containers[i].Item2.Set(_data.Containers[i].Item2);
        }

        foreach (int id in _data.HidesId)
            _containers[id].Item2.Hide();
    }

    public void SetRecipe(Recipe recipe)
    {
        if (recipe is null)
            throw new System.NullReferenceException("recipe on SetRecipe is null");

        foreach (var container in _containers)
            container.Item1.SetRecipe(recipe);
    }
}



