using UnityEngine;

public abstract class Achievement : MonoBehaviour
{
    [SerializeField, Range(1, 100)] private int _value = 1;
    [SerializeField] private Kind _kind;
    [SerializeField] private AchievementImage _image;
    protected enum Kind
    {
        All,
        Max
    }

    private void Start()
    {
        if (CanAchieve(_value, _kind))
            _image.Achieve();
    }

    protected abstract bool CanAchieve(int value, Kind kind);
}



