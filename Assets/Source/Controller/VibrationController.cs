using UnityEngine;

public class VibrationController : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _errorTime;
    [SerializeField] private Vibration.CombinationParametrs _finishCombinationParametrs;
    [SerializeField] private Vibration.CombinationParametrs _timeOutCombinationParametrs;
    private Vibration _vibration = new Vibration();

    public void FinishVibration()
    {
        _vibration.Vibrate(_finishCombinationParametrs);
    }

    public void ErrorVibration()
    {
        _vibration.Vibrate(_errorTime);
    }

    public void TimeOutVibration()
    {
        _vibration.Vibrate(_timeOutCombinationParametrs);
    }
}
