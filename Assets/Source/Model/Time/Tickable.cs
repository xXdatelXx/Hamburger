public abstract class Tickable
{
    public abstract void Tick(float deltaTime);
    public bool Interactive { get; private set; }

    public void Play()
    {
        Interactive = true;
    }

    public void Stop()
    {
        Interactive = false;
    }
}
