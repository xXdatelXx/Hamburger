public class Score
{
    private Saver<ScoreSeiazable> _saver;

    public int CurentScore { get; private set; }
    public int MaxValue => _saver.Load().MaxValue;
    public int AllValue => _saver.Load().AllScore;

    public bool NewRecord { get; private set; }

    public Score()
    {
        _saver = new Saver<ScoreSeiazable>(nameof(Score), new ScoreSeiazable());
    }

    private void TrySetMaxScore(int score)
    {
        if (score < MaxValue)
            return;

        _saver.Save(new ScoreSeiazable(score, _saver.Load().AllScore));
        NewRecord = true;
    }

    public void IncreaseScore()
    {
        CurentScore++;

        _saver.Save(new ScoreSeiazable(_saver.Load().MaxValue, ++_saver.Load().AllScore));
        TrySetMaxScore(CurentScore);
    }
}

public class ScoreSeiazable : SerializableClass
{
    public ScoreSeiazable(int maxValue = 0, int allScore = 0)
    {
        MaxValue = maxValue;
        AllScore = allScore;
    }

    public int MaxValue;
    public int AllScore;
}
