using UnityEngine;
using System.Collections.Generic;

public class RecordView : GameStateView
{
    [SerializeField] private List<ResultView> _views;

    protected override void View(GameState.States state)
    {
        foreach (var item in _views)
            item.View();
    }
}
