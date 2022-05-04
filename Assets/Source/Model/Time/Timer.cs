using System;

public class Timer : Tickable
{
    public event Action OnEnd;
    private readonly float _time;
    private float _accumulatedTime;

    private bool _finish => _accumulatedTime >= _time;

    public Timer(float time)
    {
        if (time < 0)
            throw new ArgumentOutOfRangeException();

        _time = time;
    }

    public override void Tick(float deltaTime)
    {
        if (deltaTime < 0)
            throw new ArgumentOutOfRangeException();

        if (_finish)
            return;

        AffectTime(deltaTime);
    }

    public void AddTime(float time)
    {
        if (time < 0)
            throw new ArgumentOutOfRangeException("time on addTime must be > 0");

        AffectTime(-time);
    }

    public void RemoveTime(float time)
    {
        if (time < 0)
            throw new ArgumentOutOfRangeException("time on removeTime must be > 0");

        AffectTime(time);
    }

    public float GetPercent()
    {
        return _accumulatedTime / _time * 100;
    }

    private void AffectTime(float time)
    {
        _accumulatedTime = Math.Clamp(_accumulatedTime + time, 0, _time);

        if (_finish)
            OnEnd?.Invoke();
    }
}
