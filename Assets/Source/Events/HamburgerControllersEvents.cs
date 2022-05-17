using UnityEngine;
using UnityEngine.Events;

public class HamburgerControllersEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent _onFinish;
    [SerializeField] private UnityEvent _onErrorAdd;
    [SerializeField] private UnityEvent _onAdd;

    public void Finish()
    {
        _onFinish.Invoke();
    }

    public void Error()
    {
        _onErrorAdd.Invoke();
    }

    public void Add()
    {
        _onAdd.Invoke();
    }
}
