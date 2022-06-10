public class IngredientsAchievement : Achievement
{
    protected override bool CanAchieve(int value, Kind kind)
    {
        var madeIngredients = new MadeIngredients();

        return kind switch
        {
            Kind.All => madeIngredients.AllValue >= value,
            Kind.Max => madeIngredients.MaxValue >= value,
            _ => true
        };
    }
}
