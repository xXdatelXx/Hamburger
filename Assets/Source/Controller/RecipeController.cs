using UnityEngine;
using Zenject;

public class RecipeController : MonoBehaviour
{
    [SerializeField] private RecipeControllerEvents _events;
    [SerializeField] private GameState.States _spawnState;
    private RecipeGameObjectFactory _gameObjectFactory;
    private RecipeFactory _recipeFactory;
    private Ingredients _ingredients;
    private GameState _gameState;

    [Inject]
    private void Construct(RecipeGameObjectFactory gameObjectFactory, RecipeFactory recipeFactory, Ingredients ingredients, GameState state)
    {
        _gameObjectFactory = gameObjectFactory;
        _recipeFactory = recipeFactory;
        _ingredients = ingredients;
        _gameState = state;
    }

    private void Awake()
    {
        Spawn();
    }

    private void OnEnable()
    {
        _gameState.OnSetState += HandledGameState;
    }

    private void OnDisable()
    {
        _gameState.OnSetState -= HandledGameState;
    }

    private void HandledGameState(GameState.States state)
    {
        if (_spawnState == state)
        {
            CreateNewRecipe();
            Spawn();
        }
    }

    private void Spawn()
    {
        foreach (Ingredient ingredient in _recipeFactory.Recipe.Ingredients)
            _gameObjectFactory.Create(_ingredients.Find(ingredient));
    }

    private void CreateNewRecipe()
    {
        _gameObjectFactory.DestroyAll();
        _events.OnCreateNewRecipe(_recipeFactory.Create());
    }
}
