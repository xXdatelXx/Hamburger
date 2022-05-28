using UnityEngine;

public abstract class IngredientFactory : MonoBehaviourFactory<Ingredient>
{
    private Vector2 _ingredientUpPosition;

    protected override void SetPosition(Ingredient ingredient)
    {
        float x = ingredient.transform.position.x;
        float y = _ingredientUpPosition.y - ingredient.DownLocalPosition.y;

        ingredient.transform.position = new Vector2(x, y);

        _ingredientUpPosition = ingredient.UpPosition;
    }

    public void ResetSpawnPosition()
    {
        _ingredientUpPosition = Vector2.zero;
    }
}
