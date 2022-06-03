public class IngredientsAchievement : Achievement
{
    private MadeIngredients _madeIngredients;

    private void Awake()
    {
        _madeIngredients = new MadeIngredients();
    }

    protected override bool CanAchieve(int value, Kind kind)
    {
        return kind switch
        {
            Kind.All => _madeIngredients.AllValue >= value,
            Kind.Max => _madeIngredients.MaxValue >= value,
            _ => true
        };
    }
}
