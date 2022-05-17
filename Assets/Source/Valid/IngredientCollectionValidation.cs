public class IngredientCollectionValidation
{
    public bool Equal(IngredientCollection ingredientCollection1, IngredientCollection ingredientCollection2)
    {
        if (ingredientCollection1 is null && ingredientCollection2 is null)
            return true;

        if (ingredientCollection1 is null || ingredientCollection2 is null)
            return false;

        if (ingredientCollection1.IngredientCount != ingredientCollection2.IngredientCount)
            return false;

        for (int i = 0; i < ingredientCollection2.IngredientCount; i++)
        {
            if (ingredientCollection2[i].GetType() != ingredientCollection1[i].GetType())
                return false;
        }

        return true;
    }
}
