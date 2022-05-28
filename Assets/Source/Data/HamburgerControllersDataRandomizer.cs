using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class HamburgerControllersData
{
    public List<int> HidesId;
    public readonly List<(Ingredient, Sprite)> Containers;

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
        for (int i = 0; i < randomPairCount * 2; i++)
        {
            int id = Random.Range(0, _ingredients.GetList().Count);

            while (ingredientsId.Contains(id))
                id = Random.Range(0, _ingredients.GetList().Count);

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

        for (int i = 0; i < hideItems; i++)
        {
            int id = Random.Range(0, Data.Containers.Count);

            while (Data.HidesId.Contains(id))
                id = Random.Range(0, Data.Containers.Count);

            Data.HidesId.Add(id);
        }
    }
}
