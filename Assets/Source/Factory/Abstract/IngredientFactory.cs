using UnityEngine;

public abstract class IngredientFactory : MonoBehaviourFactory<Ingredient>
{
    private Vector2 _ingredientUpPosition;
    private int _layer;

    protected override void SetPosition(Ingredient ingredient)
    {
        float x = ingredient.transform.position.x;
        float y = _ingredientUpPosition.y - ingredient.DownLocalPosition.y;

        ingredient.transform.position = new Vector2(x, y);

        _ingredientUpPosition = ingredient.UpPosition;
    }

    protected override void Init(Ingredient entity)
    {
        _layer++;
        entity.SetLayer(_layer);
    }

    public void Reset()
    {
        _ingredientUpPosition = Vector2.zero;
        _layer = 0;
    }
}
