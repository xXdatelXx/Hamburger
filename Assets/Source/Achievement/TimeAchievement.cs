public class TimeAchievement : Achievement
{
    protected override bool CanAchieve(int value, Kind kind)
    {
        var time = new TimePlay();

        return kind switch
        {
            Kind.All => time.AllTimePlay >= value,
            Kind.Max => time.MaxTimePlay >= value,
            _ => true
        };
    }
}
