using UnityEngine;

public class SceneSwitcherAnimator : MonoBehaviour
{
    [SerializeField] private Animator _menuAnimator;
    [SerializeField] private string _exit;
    [SerializeField] private SceneSwitcher _switcher;

    private void OnEnable()
    {
        _switcher.OnLoad += Exit;
    }

    private void OnDisable()
    {
        _switcher.OnLoad -= Exit;
    }

    public void Exit()
    {
        _menuAnimator.SetTrigger(_exit);
    }
}
