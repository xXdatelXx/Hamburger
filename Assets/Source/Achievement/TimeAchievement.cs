public class TimeAchievement : Achievement
{
    private TimePlay _time;

    private void Awake()
    {
        _time = new TimePlay();
    }

    protected override bool CanAchieve(int value, Kind kind)
    {
        return kind switch
        {
            Kind.All => _time.AllTimePlay >= value,
            Kind.Max => _time.MaxTimePlay >= value,
            _ => true
        };
    }
}
