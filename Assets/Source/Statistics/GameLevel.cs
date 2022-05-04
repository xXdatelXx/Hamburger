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
            return Level.first;
        if (score <= _levelBalance.ItemsInSecondLevel)
            return Level.second;
        if (score <= _levelBalance.ItemsInThirdLevel)
            return Level.third;
        if (score <= _levelBalance.ItemsInFourthtLevel)
            return Level.fourth;

        return Level.max;
    }
}

public enum Level
{
    first,
    second,
    third,
    fourth,
    max
}
