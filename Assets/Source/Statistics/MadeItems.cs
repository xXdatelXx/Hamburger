public class MadeItems
{
    private Saver<MadeItemsSeiazable> _saver;
    public int CurentMadeItems { get; private set; }
    public bool NewRecord { get; private set; }

    public MadeItems()
    {
        _saver = new Saver<MadeItemsSeiazable>(nameof(MadeItems), new MadeItemsSeiazable());
    }

    public void IncreaseMadeItems()
    {
        CurentMadeItems++;

        var saveMadeItems = _saver.Load();
        saveMadeItems.AllMadeItems++;

        if (saveMadeItems.MaxMadeItems < CurentMadeItems)
        {
            saveMadeItems.MaxMadeItems = CurentMadeItems;
            NewRecord = true;
        }

        _saver.Save(saveMadeItems);
    }
}

public class MadeItemsSeiazable : SerializableClass
{
    public MadeItemsSeiazable(int maxMadeItems = 0, int allMadeItems = 0)
    {
        MaxMadeItems = maxMadeItems;
        AllMadeItems = allMadeItems;
    }

    public int MaxMadeItems;
    public int AllMadeItems;
}
