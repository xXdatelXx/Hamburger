using UnityEngine;
using Zenject;

public class RecipeController : MonoBehaviour
{
    [SerializeField] private RecipeControllerEvents _events;
    private RecipeGameObjectFactory _gameObjectFactory;
    private RecipeFactory _recipeFactory;
    private Ingredients _ingredients;

    [Inject]
    private void Construct(RecipeGameObjectFactory gameObjectFactory, RecipeFactory recipeFactory, Ingredients ingredients)
    {
        _gameObjectFactory = gameObjectFactory;
        _recipeFactory = recipeFactory;
        _ingredients = ingredients;
    }

    private void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        foreach (Ingredient ingredient in _recipeFactory.Recipe.Ingredients)
            _gameObjectFactory.Create(_ingredients.Find(ingredient));
    }

    public void CreateNewRecipe()
    {
        _gameObjectFactory.DestroyAll();
        _events.OnCreateNewRecipe(_recipeFactory.Create());
    }
}
