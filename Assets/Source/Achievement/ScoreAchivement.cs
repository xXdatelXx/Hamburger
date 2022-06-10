public class ScoreAchivement : Achievement
{
    protected override bool CanAchieve(int value, Kind kind)
    {
        var score = new Score();

        return kind switch
        {
            Kind.All => score.AllValue >= value,
            Kind.Max => score.MaxValue >= value,
            _ => true
        };
    }
}






