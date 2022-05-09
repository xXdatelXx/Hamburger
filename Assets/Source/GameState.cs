using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPlay;
    [SerializeField] private UnityEvent _onEndPlay;
    [SerializeField] private UnityEvent _onInspectEvent;
    [SerializeField] private UnityEvent _onEndInspectEvent;
    [SerializeField] private UnityEvent _onInspectRecipe;
    [SerializeField] private UnityEvent _onEndInspectRecipe;
    [SerializeField] private UnityEvent _onFinish;
    [SerializeField] private UnityEvent _onEndFinish;
    [SerializeField] private UnityEvent _onLose;
    private States _state;
    private enum States
    {
        InspectRecipe,
        InspectEvent,
        Play,
        Lose,
        Finish
    }

    public void Play()
    {
        if (_state == States.InspectRecipe)
        {
            _state = States.Play;

            _onEndInspectEvent.Invoke();
            _onPlay.Invoke();
        }
    }

    public void Lose()
    {
        if (_state == States.Play)
        {
            _state = States.Lose;

            _onEndPlay.Invoke();
            _onLose.Invoke();
        }
    }

    public void Finish()
    {
        if (_state == States.Play)
        {
            _state = States.Finish;

            _onEndPlay.Invoke();
            _onFinish.Invoke();
        }
    }

    public void InspectEvent()
    {
        if (_state == States.Finish)
        {
            _state = States.InspectEvent;

            _onEndFinish.Invoke();
            _onInspectEvent.Invoke();
        }
    }

    public void InspectRecipe()
    {
        print(_state);
        switch (_state)
        {
            case States.InspectEvent:
                _onEndInspectRecipe.Invoke();
                break;
            case States.Finish:
                _onEndFinish.Invoke();
                break;
            default:
                return;
        }

        _state = States.InspectRecipe;

        _onInspectRecipe.Invoke();
    }
}
