using System;

public class TimePlay
{
    private Saver<TimePlaySeiazable> _saver;
    private Stopwatch _stopwatch;
    private TimePlaySeiazable _data;
    public float CurentTimePlay { get; private set; }
    public bool NewRecord => CurentTimePlay > _data.MaxTimePlay;
    public float AllTimePlay => _saver.Load().AllTimePlay;
    public float MaxTimePlay => _saver.Load().MaxTimePlay;

    public TimePlay()
    {
        _saver = new Saver<TimePlaySeiazable>(nameof(TimePlay), new TimePlaySeiazable());
        _data = _saver.Load();
    }

    public void StartPlay(Stopwatch stopwatch)
    {
        _stopwatch = stopwatch ?? throw new NullReferenceException("Stopwatch on TimePlay is null");
    }

    public void Tick()
    {
        if (_stopwatch != null)
            CurentTimePlay = _stopwatch.Time;
    }

    public void EndPlay()
    {
        if (NewRecord)
            _saver.Save(new TimePlaySeiazable(_data.AllTimePlay, CurentTimePlay));

        _data = _saver.Load();
        _saver.Save(new TimePlaySeiazable(_data.AllTimePlay + CurentTimePlay, _data.MaxTimePlay));

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
