using Zenject;

public class MadeIngredientsView : ResultView
{
    [Inject] private MadeIngredients _madeIngredients;

    protected override float GetResult()
    {
        return _madeIngredients.CurentMadeIngredients;
    }

    protected override bool NewRecord()
    {
        return _madeIngredients.NewRecord;
    }
}
