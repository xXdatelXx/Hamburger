using UnityEngine;

public abstract class Achievement : MonoBehaviour
{
    [SerializeField, Range(1, 100)] private int _value = 1;
    [SerializeField] private Kind _kind;
    [SerializeField] private AchievementImage _image;
    public bool Achieve { get; private set; }
    protected enum Kind
    {
        All,
        Max
    }

    private void Awake()
    {
        if (CanAchieve(_value, _kind))
        {
            Achieve = true;
            _image.Achieve();
        }
    }

    private bool CanAchieve(int value, Kind kind)
    {
        int maxValue, allValue;
        GetValue(out maxValue, out allValue);

        return kind switch
        {
            Kind.All => allValue >= value,
            Kind.Max => maxValue >= value,
            _ => true
        };
    }

    protected abstract void GetValue(out int maxValue, out int allValue);
}



