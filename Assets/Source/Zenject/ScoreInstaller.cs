using Zenject;

public class ScoreInstaller : MonoInstaller
{
    public Score Score { get; private set; }
    public TimePlay TimePlay { get; private set; }
    public MadeIngredients MadeIngredients { get; private set; }
    public TimeMadeIngredients TimeBetweenMadeIngredients { get; private set; }

    public override void InstallBindings()
    {
        Container.BindInstance(Score = new Score());
        Container.BindInstance(TimePlay = new TimePlay());
        Container.BindInstance(MadeIngredients = new MadeIngredients());
        Container.BindInstance(TimeBetweenMadeIngredients = new TimeMadeIngredients());
    }
}
