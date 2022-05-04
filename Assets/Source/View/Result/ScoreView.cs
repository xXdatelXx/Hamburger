using Zenject;

public class ScoreView : ResultView
{
    [Inject] private Score _score;

    protected override float GetResult()
    {
        return _score.CurentScore;
    }

    protected override bool NewRecord()
    {
        return _score.NewRecord;
    }
}
