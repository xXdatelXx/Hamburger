using UnityEngine;
using Zenject;

public abstract class GameStateView : MonoBehaviour
{
    [SerializeField] private GameState.States _viewState;
    private GameState _state;

    [Inject]
    private void Construct(GameState state)
    {
        _state = state;
    }

    private void OnEnable()
    {
        _state.OnSetState += TryView;
    }

    private void OnDisable()
    {
        _state.OnSetState -= TryView;
    }

    private void TryView(GameState.States state)
    {
        if (state == _viewState)
            View(state);
    }

    protected abstract void View(GameState.States state);
}
