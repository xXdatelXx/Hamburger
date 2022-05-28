using Zenject;

public class MaxScoreView : ResultView
{
    [Inject] private Score _score;

    protected override float GetResult()
    {
        return _score.MaxValue;
    }
}
