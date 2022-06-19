public class IngredientsAchievement : Achievement
{
    protected override void GetValue(out int maxValue, out int allValue)
    {
        var madeIngredients = new MadeIngredients();

        maxValue = madeIngredients.MaxValue;
        allValue = madeIngredients.AllValue;
    }
}
