using Zenject;

public class MaxMadedIngredientsView : ResultView
{
    [Inject] private MadeIngredients _madeIngredients;

    protected override float GetResult()
    {
        return _madeIngredients.MaxMadeIngredients;
    }
}
