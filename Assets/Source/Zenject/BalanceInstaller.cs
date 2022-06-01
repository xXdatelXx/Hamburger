using UnityEngine;
using Zenject;

public class BalanceInstaller : MonoInstaller
{
    [SerializeField] private TimerBalance _timerBalance;
    public TimerBalance Timer => _timerBalance;
    [SerializeField] private LevelBalance _levelBalance;
    public LevelBalance Level => _levelBalance;
    [SerializeField] private HideIngredientsBalance _hideIngredientsBalance;
    public HideIngredientsBalance Hide => _hideIngredientsBalance;
    [SerializeField] private IngredientsInLevelBalance _ingredientsInLevelBalance;
    public IngredientsInLevelBalance Ingredients => _ingredientsInLevelBalance;
    [SerializeField] private EventBalance _eventBalance;
    public EventBalance Event => _eventBalance;

    public override void InstallBindings()
    {
        Container.BindInstances(_timerBalance);
        Container.BindInstances(_levelBalance);
        Container.BindInstances(_eventBalance);
        Container.BindInstance(_hideIngredientsBalance);
        Container.BindInstance(_ingredientsInLevelBalance);
    }
}
