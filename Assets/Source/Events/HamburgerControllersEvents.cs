using UnityEngine;
using UnityEngine.Events;

public class HamburgerControllersEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent OnFinish;
    [SerializeField] private UnityEvent OnErrorAdd;
    [SerializeField] private UnityEvent OnAdd;

    public void Finish()
    {
        OnFinish?.Invoke();
    }

    public void Error()
    {
        OnErrorAdd?.Invoke();
    }

    public void Add()
    {
        OnAdd?.Invoke();
    }
}
