using Zenject;
using System;

public class TimePlayView : ResultView
{
    [Inject] private TimePlay _timePlay;

    protected override float GetResult()
    {
        return (float)Math.Round((decimal)_timePlay.CurentTimePlay, 3);
    }

    protected override bool NewRecord()
    {
        return _timePlay.NewRecord;
    }
}
