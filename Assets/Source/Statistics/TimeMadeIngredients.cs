using System.Collections.Generic;
using System.Linq;
using System;

public class TimeMadeIngredients
{
    private Saver<TimeMadeIngredientsSeiazable> _saver;
    private Stopwatch _stopwatch;
    private List<float> _allTimes;
    private bool _init;
    public float CurentTime { get; private set; }
    public float MinTime => _saver.Load().AllTimes.Min();
    public float AllAvarageTime => GetAvarageTime();
    public bool NewRecord { get; private set; }

    public TimeMadeIngredients()
    {
        _saver = new Saver<TimeMadeIngredientsSeiazable>(nameof(TimeMadeIngredients), new TimeMadeIngredientsSeiazable());
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

    }

    public void End()
    {
        CheckRecord();
        SetAllTimes();
    }

    private void SetTime()
    {
        if (!_init)
            return;

        float allTime = 0;
        for (int i = 0; i < _allTimes.Count; i++)
            allTime += _allTimes[i];

        CurentTime = allTime / _allTimes.Count;
    }

    private void CheckRecord()
    {
        if (CurentTime == 0)
            return;

        if (MinTime > CurentTime)
            NewRecord = true;
    }

    private void SetAllTimes()
    {
        var timeMadeItems = _saver.Load();

        var allTimes = timeMadeItems.AllTimes;
        allTimes.Add(CurentTime);
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

public class TimeMadeIngredientsSeiazable : SerializableClass
{
    public TimeMadeIngredientsSeiazable(List<float> allTimes = null)
    {
        AllTimes = allTimes;
    }

    public List<float> AllTimes;
}
