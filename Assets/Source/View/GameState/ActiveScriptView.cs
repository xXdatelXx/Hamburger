using UnityEngine;

public class ActiveScriptView : GameStateView
{
    [SerializeField] private MonoBehaviour _script;
    [SerializeField] private bool _active;

    protected override void View(GameState.States state)
    {
        _script.enabled = _active;
    }
}
