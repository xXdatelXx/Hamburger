using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Balance/Timer", fileName = "TimerBalance")]
public class TimerBalance : ScriptableObject
{
    [SerializeField, Range(10, 100)] private int _timerTime = 10;
    public int Time => _timerTime;

    [SerializeField, Range(1, 10)] private int _hamburgerAddTime = 5;
    public int HamburgerAddTime => _hamburgerAddTime;

    [SerializeField, Range(1, 10)] private int _errorRemoveTime = 1;
    public int ErrorRemoveTime => _hamburgerAddTime;

    private void OnValidate()
    {
        if (_timerTime < 10)
            _timerTime = 10;
        if (_hamburgerAddTime < 1)
            _hamburgerAddTime = 1;
        if (_errorRemoveTime < 1)
            _errorRemoveTime = 1;
    }
}
