public class MadeIngredients
{
    private Saver<MadeIngredientSeiazable> _saver;
    public int CurentMadeIngredients { get; private set; }
    public bool NewRecord { get; private set; }

    public MadeIngredients()
    {
        _saver = new Saver<MadeIngredientSeiazable>(nameof(MadeIngredients), new MadeIngredientSeiazable());
    }

    public void IncreaseMadeItems()
    {
        CurentMadeIngredients++;

        var saveMadeIngredients = _saver.Load();
        saveMadeIngredients.AllMadeIngredients++;

        if (saveMadeIngredients.MaxMadeIngredients < CurentMadeIngredients)
        {
            saveMadeIngredients.MaxMadeIngredients = CurentMadeIngredients;
            NewRecord = true;
        }

        _saver.Save(saveMadeIngredients);
    }
}

public class MadeIngredientSeiazable : SerializableClass
{
    public MadeIngredientSeiazable(int maxMadeIngredients = 0, int allMadeIngredients = 0)
    {
        MaxMadeIngredients = maxMadeIngredients;
        AllMadeIngredients = allMadeIngredients;
    }

    public int MaxMadeIngredients;
    public int AllMadeIngredients;
}
