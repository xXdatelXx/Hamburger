using Zenject;

public class MadeItemsView : ResultView
{
    [Inject] private MadeItems _madeItems;

    protected override float GetResult()
    {
        return _madeItems.CurentMadeItems;
    }

    protected override bool NewRecord()
    {
        return _madeItems.NewRecord;
    }
}
