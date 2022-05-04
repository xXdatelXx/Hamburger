using System;

public class Stopwatch : Tickable
{
    public float Time { get; private set; }

    public override void Tick(float deltaTime)
    {
        if (deltaTime < 0)
            throw new ArgumentOutOfRangeException();

        Time += deltaTime;
    }

    public void Reset()
    {
        Time = 0;
    }
}
