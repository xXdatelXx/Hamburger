public class TimeAchievement : Achievement
{
    protected override void GetValue(out int maxValue, out int allValue)
    {
        var time = new TimePlay();

        maxValue = (int)time.AllTimePlay;
        allValue = (int)time.MaxTimePlay;
    }
}
