using Zenject;
using System;

public class TimeBetweenMadeItemsView : ResultView
{
    [Inject] private TimeMadeItems _timeMadeItems;

    protected override float GetResult()
    {
        return (float)Math.Round((double)_timeMadeItems.CurentTime, 3);
    }

    protected override bool NewRecord()
    {
        return _timeMadeItems.NewRecord;
    }
}
