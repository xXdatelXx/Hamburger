using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class HamburgerControllersData
{
    public readonly List<(Ingredient, Sprite)> Containers;
    public List<int> HidesId;

    public HamburgerControllersData(List<int> hidesId, List<(Ingredient, Sprite)> containers)
    {
        HidesId = hidesId;
        Containers = containers;
    }
}

public class HamburgerControllersDataRandomizer
{
    public HamburgerControllersData Data { get; private set; }
    private readonly Ingredients _ingredients;

    public HamburgerControllersDataRandomizer(Ingredients ingredients, HamburgerControllersSprites hamburgerControllersSprites)
    {
        _ingredients = ingredients;
        Data = new HamburgerControllersData(new List<int>(), ingredients.GetList().Select((t, i) => (t, hamburgerControllersSprites.Sprites[i])).ToList());
    }

    public void RandomizeIngredient(int randomPairCount)
    {
        if (randomPairCount < 0)
            return;

        var ingredientsId = new List<int>();

        if (_ingredients.GetList().Count < randomPairCount)
            return;

        for (int i = 0; i < randomPairCount * 2; i++)
        {
            int id = Random.Range(0, _ingredients.GetList().Count);

            if (ingredientsId.Contains(id))
            {
                i--;
                continue;
            }

            ingredientsId.Add(id);
        }

        foreach (int id in ingredientsId)
            (Data.Containers[id], Data.Containers[ingredientsId[^1]]) = (Data.Containers[ingredientsId[^1]], Data.Containers[id]);
    }

    public void RandomizeHidesId(int hideItems)
    {
        if (hideItems > Data.Containers.Count)
            hideItems = Data.Containers.Count;

        Data.HidesId = new List<int>();

        if (Data.Containers.Count < hideItems)
            return;

        for (int i = 0; i < hideItems; i++)
        {
            int id = Random.Range(0, Data.Containers.Count);

            if (Data.HidesId.Contains(id))
            {
                i--;
                continue;
            }

            Data.HidesId.Add(id);
        }
    }
}
