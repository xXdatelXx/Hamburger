public class BalanceValidate
{
    public void ValidateValue(ref int value1, int value2)
    {
        if (value1 < value2)
            value1 = value2 + 1;
    }
}
