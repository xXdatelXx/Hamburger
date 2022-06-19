using UnityEngine;
using Zenject;

public abstract class IngredientFactory : MonoBehaviourFactory<Ingredient>
{
    [SerializeField] private GameState.States _resetState;
    [SerializeField] private GameState.States _destroyState;
    private Vector2 _ingredientUpPosition;
    private int _layer;
    private GameState _gameState;

    [Inject]
    private void Construct(GameState state)
    {
        _gameState = state;
    }

    private void OnEnable()
    {
        _gameState.OnSetState += TryReset;
        _gameState.OnSetState += TryDestroy;
    }

    private void OnDisable()
    {
        _gameState.OnSetState -= TryReset;
        _gameState.OnSetState -= TryDestroy;
    }

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

    private void TryReset(GameState.States state)
    {
        if (state == _resetState)
        {
            _ingredientUpPosition = Vector2.zero;
            _layer = 0;
        }
    }

    private void TryDestroy(GameState.States state)
    {
        if (state == _destroyState)
            DestroyAll();
    }
}
