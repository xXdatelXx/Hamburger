using UnityEngine;
using System;

public class GameState : MonoBehaviour
{
    private States _state;
    public event Action<States> OnSetState;
    public enum States
    {
        MainMenu,
        InspectRecipe,
        InspectEvent,
        EndInspectEvent,
        Play,
        Lose,
        Finish,
        Null
    }

    public void Play()
    {
        switch (_state)
        {
            case States.MainMenu:
                OnSetState?.Invoke(States.MainMenu);
                break;
            case States.InspectRecipe:
                break;
            default:
                return;
        }

        OnSetState?.Invoke(_state = States.Play);
    }

    public void Lose()
    {
        if (_state == States.Play)
            OnSetState?.Invoke(_state = States.Lose);
    }

    public void Finish()
    {
        if (_state == States.Play)
            OnSetState?.Invoke(_state = States.Finish);
    }

    public void InspectEvent()
    {
        if (_state == States.Finish)
            OnSetState?.Invoke(_state = States.InspectEvent);
    }

    public void InspectRecipe()
    {
        if (_state == States.InspectEvent)
            OnSetState?.Invoke(States.EndInspectEvent);

        OnSetState?.Invoke(_state = States.InspectRecipe);
    }
}
