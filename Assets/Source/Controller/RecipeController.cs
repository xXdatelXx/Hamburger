using UnityEngine;
using Zenject;

public class RecipeController : MonoBehaviour
{
    [SerializeField] private RecipeControllerEvents _events;
    [Inject] private readonly RecipeItemFactory _itemFactory;
    [Inject] private readonly RecipeFactory _recipeFactory;
    [Inject] private readonly ItemsList _itemsList;

    private void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        foreach (Item item in _recipeFactory.Recipe.Items)
            _itemFactory.Create(_itemsList.Find(item));
    }

    public void CreateNewRecipe()
    {
        _itemFactory.DestroyAll();
        _events.OnCreateNewRecipe(_recipeFactory.Create());
    }
}
