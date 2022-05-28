using System;
using System.Collections.Generic;
using UnityEngine;

public class TickableController : MonoBehaviour
{
    private readonly List<Tickable> _tickables = new List<Tickable>();

    private void FixedUpdate()
    {
        foreach (var tickable in _tickables)
            if (tickable.Interactive)
                tickable.Tick(Time.fixedDeltaTime);
    }

    public void Add(Tickable tickable)
    {
        if (tickable is null)
            throw new ArgumentNullException(nameof(tickable));

        _tickables.Add(tickable);
    }

    public void Remove(Tickable tickable)
    {
        _tickables.Remove(tickable);
    }
}
