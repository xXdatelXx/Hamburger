using Zenject;
using System;

public class AllTimePlayView : ResultView
{
    [Inject] private TimePlay _timePlay;

    protected override float GetResult()
    {
        return (float)Math.Round(_timePlay.MaxTimePlay, 3);
    }
}
