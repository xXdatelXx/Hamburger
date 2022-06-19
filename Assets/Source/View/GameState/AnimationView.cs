using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationView : GameStateView
{
    [SerializeField] private string _animationTrigger;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void View(GameState.States state)
    {
        _animator.SetTrigger(_animationTrigger);
    }
}
