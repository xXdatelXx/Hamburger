using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;

public class RecipeTest
{
    /// private RecipeStrategy _recipeStrategy = new RecipeStrategy();
   // private RecipeFactory _factory = new RecipeFactory();

    [UnityTest]
    public IEnumerator DontCan_AddIncorectTo_RecipeStrategy()
    {
        // _recipeStrategy.SetRecipe(_factory.Create());
        // bool canAddNull = _recipeStrategy.CanAdd(null);
        // bool canAddIncorectItem = _recipeStrategy.CanAdd(new IncorectItem());

        //  Assert.AreEqual(canAddNull, false);
        //  Assert.AreEqual(canAddIncorectItem, false);
        yield break;
    }

    [UnityTest]
    public IEnumerator ItemsInRecipeFactory_IsNotEqual_Null()
    {
        //   var recipe = _factory.Create();

        bool recipeItemsIsNull = false;

        // foreach (var item in recipe)
        //     recipeItemsIsNull = item is null;

        Assert.AreEqual(recipeItemsIsNull, false);
        yield break;
    }

    [UnityTest]
    public IEnumerator RecipeHas_BreadDown_And_BreadUp()
    {
        //var recipe = _factory.Create();

        // bool breadDownInRecipe = recipe[0].GetType() == new BreadDownItem().GetType();
        //  bool BreadUpInRecipe = recipe[recipe.Count - 1].GetType() == new BreadUpItem().GetType();

        //   Assert.AreEqual(breadDownInRecipe, true);
        //  Assert.AreEqual(BreadUpInRecipe, true);
        yield break;
    }

    [Test]
    public void FinishIn_RecipeStrategy_DoCorrectly()
    {
        //  Recipe recipe = new Recipe()
        //  {
        //       new MeatItem()
        //   };
        //   _recipeStrategy.SetRecipe(recipe);

        bool doCorrectly = false;
        // _recipeStrategy.OnFinish += () => doCorrectly = true;
        // doCorrectly = _recipeStrategy.CanAdd(recipe[0]);

        Assert.AreEqual(doCorrectly, true);
    }

    class IncorectIngredient : Ingredient
    { }
}
