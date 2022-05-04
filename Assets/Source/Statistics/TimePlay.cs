using System;

public class TimePlay
{
    private Saver<TimePlaySeiazable> _saver;
    private Stopwatch _stopwatch;
    public float CurentTimePlay { get; private set; }
    public bool NewRecord { get; private set; }
    public float AllTimePlay => _saver.Load().AllTimePlay;
    public float MaxTimePlay => _saver.Load().MaxTimePlay;

    public TimePlay()
    {
        _saver = new Saver<TimePlaySeiazable>(nameof(TimePlay), new TimePlaySeiazable());
    }

    public void StartPlay(Stopwatch stopwatch)
    {
        if (stopwatch is null)
            throw new NullReferenceException("Stopwatch on TimePlay is null");

        _stopwatch = stopwatch;
    }

    public void EndPlay()
    {
        CurentTimePlay = _stopwatch.Time;
        var timePlay = _saver.Load();

        if (CurentTimePlay > timePlay.MaxTimePlay)
        {
            _saver.Save(new TimePlaySeiazable(timePlay.AllTimePlay, CurentTimePlay));
            NewRecord = true;
        }

        timePlay = _saver.Load();
        _saver.Save(new TimePlaySeiazable(timePlay.AllTimePlay + CurentTimePlay, timePlay.MaxTimePlay));

        _stopwatch = null;
    }
}

public class TimePlaySeiazable : SerializableClass
{
    public TimePlaySeiazable(float allTimePlay = 0, float maxTimePlay = 0)
    {
        AllTimePlay = allTimePlay;
        MaxTimePlay = maxTimePlay;
    }

    public float AllTimePlay;
    public float MaxTimePlay;
}
