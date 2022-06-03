using Zenject;

public class AllMadeIngredientsView : ResultView
{
    [Inject] private MadeIngredients _madeIngredients;

    protected override float GetResult()
    {
        return _madeIngredients.AllValue;
    }
}
