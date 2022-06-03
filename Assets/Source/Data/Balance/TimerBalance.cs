using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Balance/Timer", fileName = "TimerBalance")]
public class TimerBalance : ScriptableObject
{
    [field: SerializeField, Range(10, 100)] public int Time { get; private set; }
    [field: SerializeField, Range(1, 10)] public int HamburgerAddTime { get; private set; }
    [field: SerializeField, Range(1, 10)] public int ErrorRemoveTime { get; private set; }

    private void OnValidate()
    {
        if (Time < 10)
            Time = 10;
        if (HamburgerAddTime < 1)
            HamburgerAddTime = 1;
        if (ErrorRemoveTime < 1)
            ErrorRemoveTime = 1;
    }
}
