using System.Collections.Generic;
using System;

public class TimeMadeItems
{
    private Saver<TimeMadeItemsSeiazable> _saver;
    private float _curentTime;
    private Stopwatch _stopwatch;
    private List<float> _allTimes;
    private bool _init;
    public float MinTime => _saver.Load().MinTime;
    public float AllAvarageTime => GetAvarageTime();
    public bool NewRecord { get; private set; }

    public TimeMadeItems()
    {
        _saver = new Saver<TimeMadeItemsSeiazable>(nameof(TimeMadeItems), new TimeMadeItemsSeiazable());
    }

    public void SetStopwatch(Stopwatch stopwatch)
    {
        if (stopwatch is null)
            throw new NullReferenceException("Stopwatch on TimePlay is null");

        _stopwatch = stopwatch;
        _allTimes = new List<float>();

        _init = true;
    }

    public void Play()
    {
        if (_init)
            _stopwatch.Play();
    }

    public void Tick()
    {
        if (!_init)
            return;

        _allTimes.Add(_stopwatch.Time);
        SetTime();
        _stopwatch.Reset();
    }

    public void Stop()
    {
        if (!_init)
            return;

        _stopwatch.Stop();

        SetAllTimes();
    }

    private void SetTime()
    {
        if (!_init)
            return;

        TrySetMinTime();

        float allTime = 0;
        for (int i = 0; i < _allTimes.Count; i++)
            allTime += _allTimes[i];

        _curentTime = allTime / _allTimes.Count;

    }

    private void TrySetMinTime()
    {
        var timeMadeItems = _saver.Load();

        if (timeMadeItems.MinTime == 0 ||
            timeMadeItems.MinTime > _curentTime)
        {
            timeMadeItems.MinTime = _curentTime;
            _saver.Save(timeMadeItems);
            NewRecord = true;
        }
    }

    private void SetAllTimes()
    {
        var timeMadeItems = _saver.Load();

        var allTimes = timeMadeItems.AllTimes;
        allTimes.Add(_curentTime);
        timeMadeItems.AllTimes = allTimes;

        _saver.Save(timeMadeItems);
    }

    private float GetAvarageTime()
    {
        var allTimes = _saver.Load().AllTimes;

        float allTime = 0;
        for (int i = 0; i < _allTimes.Count; i++)
            allTime += _allTimes[i];

        return allTime / allTimes.Count;
    }
}

public class TimeMadeItemsSeiazable : SerializableClass
{
    public TimeMadeItemsSeiazable(List<float> allTimes = null, float minTime = 0)
    {
        AllTimes = allTimes;
        MinTime = minTime;
    }

    public List<float> AllTimes;
    public float MinTime;
}
