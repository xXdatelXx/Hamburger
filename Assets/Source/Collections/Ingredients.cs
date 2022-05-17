using System.Collections.Generic;
using UnityEngine;
using System;

public class Ingredients : MonoBehaviour
{
    [SerializeField] private BreadBottom _breadBottom;
    [SerializeField] private BreadTop _breadTop;
    [SerializeField] private Chease _chease;
    [SerializeField] private Green _green;
    [SerializeField] private Healmanth _healmanth;
    [SerializeField] private Ketchup _ketchup;
    [SerializeField] private Meat _meat;
    public int Count => GetList().Count;

    public List<Ingredient> GetList()
    {
        return new List<Ingredient>()
        {
            _breadBottom,
            _breadTop,
            _chease,
            _green,
            _healmanth,
            _ketchup,
            _meat
         };
    }

    public Ingredient Find(Ingredient ingredient)
    {
        var ingredients = GetList();
        foreach (var i in ingredients)
        {
            if (i.GetType() == ingredient.GetType())
                return i;
        }

        throw new InvalidOperationException("ingredientList dont contain " + ingredient.GetType());
    }
}
