using System.Collections.Generic;
using System.Linq;
using System;

public class TimeMadeIngredients
{
    private Saver<TimeMadeIngredientsSeiazable> _saver;
    private TimeMadeIngredientsSeiazable _data;
    private Stopwatch _stopwatch;
    private List<float> _allTimes;
    private bool _init;
    public float CurentTime { get; private set; }
    public float AllAvarageTime => GetAvarageTime();
    public bool NewRecord => _data.AllTimes.Count == 0 || _data.AllTimes.Min() > CurentTime && CurentTime > 0;

    public TimeMadeIngredients()
    {
        _saver = new Saver<TimeMadeIngredientsSeiazable>(nameof(TimeMadeIngredients), new TimeMadeIngredientsSeiazable());
        _data = _saver.Load();
    }

    public void SetStopwatch(Stopwatch stopwatch)
    {
        _stopwatch = stopwatch ?? throw new NullReferenceException("Stopwatch on TimePlay is null");
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
        SetAllTimes();
    }

    private void SetTime()
    {
        if (!_init)
            return;

        float allTime = _allTimes.Sum();

        CurentTime = allTime / _allTimes.Count;
    }

    private void SetAllTimes()
    {
        if (CurentTime == 0)
            return;

        var timeMadeItems = _saver.Load();

        var allTimes = timeMadeItems.AllTimes;
        allTimes.Add(CurentTime);
        timeMadeItems.AllTimes = allTimes;

        _saver.Save(timeMadeItems);
        _data = _saver.Load();
    }

    private float GetAvarageTime()
    {
        var allTimes = _data.AllTimes;

        if (allTimes.Count == 0)
            return 0;

        float allTime = allTimes.Sum();
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
