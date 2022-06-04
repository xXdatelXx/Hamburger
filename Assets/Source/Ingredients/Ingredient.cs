using UnityEngine;
using System;

public abstract class Ingredient : MonoBehaviour
{
    [SerializeField] private Transform _downPosition;
    [SerializeField] private Transform _upPosition;

    private void Awake()
    {
        if (_downPosition == null || _upPosition == null)
        {
            enabled = false;
            throw new NullReferenceException("downPosition or upPosition is null");
        }
    }

    public Vector2 DownLocalPosition => _downPosition.localPosition;
    public Vector2 UpPosition => _upPosition.position;
}
