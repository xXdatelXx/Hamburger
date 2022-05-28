using Zenject;
using System;

public class MaxAverageTimeToCreateIngredientView : ResultView
{
    [Inject] private TimeMadeIngredients _timeMadeIngredients;

    protected override float GetResult()
    {
        return (float)Math.Round(_timeMadeIngredients.AllAvarageTime, 3);
    }
}
