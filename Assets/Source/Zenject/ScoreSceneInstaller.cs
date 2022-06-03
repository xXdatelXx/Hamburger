using Zenject;

public class ScoreSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(new Score());
        Container.BindInstance(new TimePlay());
        Container.BindInstance(new MadeIngredients());
        Container.BindInstance(new TimeMadeIngredients());
    }
}
