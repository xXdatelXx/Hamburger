using UnityEngine;

public abstract class IngredientFactory : MonoBehaviourFactory<Ingredient>
{
    private Vector2 _ingredientUpPosition;

    protected override void SetPosition(Ingredient ingredient)
    {
        float positionX = ingredient.transform.position.x;

        ingredient.transform.position = _ingredientUpPosition - ingredient.DownLocalPosition;
        ingredient.transform.position = new Vector2(positionX, ingredient.transform.position.y);

        _ingredientUpPosition = ingredient.UpPosition;
    }

    public void ResetSpawnPosition()
    {
        _ingredientUpPosition = Vector2.zero;
    }
}
