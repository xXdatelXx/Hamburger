public class GameLevel
{
    private readonly LevelBalance _levelBalance;
    private readonly Score _score;

    public GameLevel(LevelBalance levelBalance, Score score)
    {
        _levelBalance = levelBalance;
        _score = score;
    }

    public Level GetGameLevel()
    {
        int score = _score.CurentScore;

        if (score <= _levelBalance.ItemsInFirstLevel)
            return Level.First;
        if (score <= _levelBalance.ItemsInSecondLevel)
            return Level.Second;
        if (score <= _levelBalance.ItemsInThirdLevel)
            return Level.Third;
        if (score <= _levelBalance.ItemsInFourthtLevel)
            return Level.Fourth;

        return Level.Max;
    }
}

public enum Level
{
    First,
    Second,
    Third,
    Fourth,
    Max
}
