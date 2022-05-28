using UnityEngine;

public class SceneSwitcherAnimator : MonoBehaviour
{
    [SerializeField] private Animator _menuAnimator;
    [SerializeField] private string _leftTrigger;
    [SerializeField] private string _rightTrigger;

    public void SwitchLeft()
    {
        _menuAnimator.SetTrigger(_leftTrigger);
    }

    public void SwitchRight()
    {
        _menuAnimator.SetTrigger(_rightTrigger);
    }
}
