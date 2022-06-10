using UnityEngine;
using System.Collections.Generic;
using System;

public class Vibration
{
#if UNITY_ANDROID && !UNITY_EDITOR

    private AndroidJavaObject _vibrator;
    private const string PascalCase = "vibrate";

    private void Awake()
    {
        _vibrator = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
        .GetStatic<AndroidJavaObject>("currentActivity")
        .Call<AndroidJavaObject>("getSystemService", PascalCase);
    }

    public void Vibrate(float time)
    {
        _vibrator.Call(PascalCase, time);
    }

    public void Vibrate(CombinationParametrs parametrs)
    {
        _vibrator.Call(PascalCase, parametrs.Times, parametrs.Reapeat);
    }

#else

    public void Vibrate(float time)
    {
    }

    public void Vibrate(CombinationParametrs parametrs)
    {
    }

#endif

    [Serializable]
    public struct CombinationParametrs
    {
        [SerializeField] private List<float> _times;
        public IReadOnlyList<float> Times => _times;
        [field: SerializeField] public int Reapeat { get; private set; }
    }
}

