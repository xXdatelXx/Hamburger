using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class HamburgerTest
{
    [Inject] private Hamburger _hamburger;
    // private RecipeStrategy _recipeStrategy = new RecipeStrategy();

    [UnityTest]
    public IEnumerator HamburgerController_AddItemTo_HamburgerSimulation()
    {
        var controller = new GameObject().AddComponent<HamburgerController>();
        var meat = new GameObject().AddComponent<MeatItem>();

        //_recipeStrategy.SetRecipe(new Recipe() { new MeatItem() });

        controller.InIt(meat);
        controller.TryAdd();

        // Assert.AreEqual(true, _hamburger.Items[0].Equals(meat));
        yield break;
    }
}
