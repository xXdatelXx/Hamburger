public class ItemsCollectionValidation
{
    public bool Equal(ItemsCollection itemsCollection1, ItemsCollection itemsCollection2)
    {
        if (itemsCollection1 is null && itemsCollection2 is null)
            return true;

        if (itemsCollection1 is null || itemsCollection2 is null)
            return false;

        if (itemsCollection1.ItemCount != itemsCollection2.ItemCount)
            return false;

        for (int i = 0; i < itemsCollection2.ItemCount; i++)
        {
            if (itemsCollection2[i].GetType() != itemsCollection1[i].GetType())
                return false;
        }

        return true;
    }
}
