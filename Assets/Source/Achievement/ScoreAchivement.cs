public class ScoreAchivement : Achievement
{
    protected override void GetValue(out int maxValue, out int allValue)
    {
        var score = new Score();

        maxValue = score.MaxValue;
        allValue = score.AllValue;
    }
}






