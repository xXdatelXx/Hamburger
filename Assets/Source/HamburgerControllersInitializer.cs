using System.Collections.Generic;

public class HamburgerControllersInitializer
{
    private HamburgerControllersData _data;

    public HamburgerControllersInitializer(HamburgerControllersData data)
    {
        _data = data;
    }

    public void Init(List<(HamburgerController, HamburgerControllerImage)> containers)
    {
        for (int i = 0; i < containers.Count; i++)
        {
            containers[i].Item1.SetIngredient(_data.Containers[i].Item1);
            containers[i].Item2.Set(_data.Containers[i].Item2);
        }

        foreach (int id in _data.HidesId)
            containers[id].Item2.Hide();
    }

    public void SetRecipe(Recipe recipe, List<(HamburgerController, HamburgerControllerImage)> containers)
    {
        if (recipe is null)
            throw new System.NullReferenceException("recipe on SetRecipe is null");

        foreach (var container in containers)
            container.Item1.SetRecipe(recipe);
    }
}
