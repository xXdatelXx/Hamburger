public class ScoreAchivement : Achievement
{
    private Score _score;

    private void Awake()
    {
        _score = new Score();
    }

    protected override bool CanAchieve(int value, Kind kind)
    {
        return kind switch
        {
            Kind.All => _score.AllValue >= value,
            Kind.Max => _score.MaxValue >= value,
            _ => true
        };
    }
}






