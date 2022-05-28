using Zenject;
using System;

public class TimeBetweenMadeIngredientsView : ResultView
{
    [Inject] private TimeMadeIngredients _timeMadeIngredients;

    protected override float GetResult()
    {
        return (float)Math.Round(_timeMadeIngredients.CurentTime, 3);
    }

    protected override bool NewRecord()
    {
        return _timeMadeIngredients.NewRecord;
    }
}
