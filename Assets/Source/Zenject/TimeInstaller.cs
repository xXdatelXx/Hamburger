using UnityEngine;
using Zenject;

public class TimeInstaller : MonoInstaller
{
    [SerializeField] private TickableController _tickableController;
    [SerializeField] private TimerBalance _timerBalance;
    public TickableController TickableController => _tickableController;
    public Timer Timer { get; private set; }

    public override void InstallBindings()
    {
        Container.BindInstance(_tickableController);
        Container.BindInstance(Timer = new Timer(_timerBalance.Time));
    }
}
