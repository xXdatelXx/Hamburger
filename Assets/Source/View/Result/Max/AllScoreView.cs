using Zenject;

public class AllScoreView : ResultView
{
    [Inject] private Score _score;

    protected override float GetResult()
    {
        return _score.AllValue;
    }
}
