using UnityEngine;
using UnityEngine.Events;

public class RecipeControllerEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent<Recipe> _onCreateNewRecipe;

    public void OnCreateNewRecipe(Recipe recipe)
    {
        _onCreateNewRecipe.Invoke(recipe);
    }
}
