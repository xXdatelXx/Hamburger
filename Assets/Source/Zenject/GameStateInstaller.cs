using UnityEngine;
using Zenject;

public class GameStateInstaller : MonoInstaller
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private LevelBalance _levelBalance;
    [SerializeField] private Score _score;
    public GameState GameState => _gameState;
    public GameLevel GameLevel { get; private set; }

    public override void InstallBindings()
    {
        Container.BindInstance(_gameState);
        Container.BindInstance(GameLevel = new GameLevel(_levelBalance, _score));
    }
}