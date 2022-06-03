using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private HamburgerFactory _hamburgerFactory;
    [SerializeField] private RecipeGameObjectFactory _recipeGameObjectFactory;
    [SerializeField] private HamburgerControllersEvents _hamburgerControllerEvents;
    [SerializeField] private Ingredients _ingredients;
    [SerializeField] private HamburgerControllersSprites _hamburgerControllersSprites;
    [SerializeField] private TimerBalance _timerBalance;
    [SerializeField] private LevelBalance _levelBalance;
    [SerializeField] private EventBalance _eventBalance;
    [SerializeField] private HideIngredientsBalance _hideIngredientsBalance;
    [SerializeField] private IngredientsInLevelBalance _ingredientsInLevelBalance;
    [SerializeField] private TickableController _tickableController;
    [SerializeField] private GameState _gameState;

    private Hamburger _hamburger;
    private RecipeFactory _recipeFactory;
    private HamburgerValid _hamburgerValid;
    private Timer _timer;
    private MadeIngredients _madeIngredients;
    private Score _score;
    private TimePlay _timePlay;
    private TimeMadeIngredients _timeBetweenMadeIngredients;
    private GameLevel _gameLevel;
    private HamburgerControllersInitializerFactory _hamburgerControllersInitializerFactory;
    private HamburgerControllersDataRandomizer _hamburgerControllersDataRandomizer;

    public override void InstallBindings()
    {
        CreateInstance();
        BindRecipe();
        BindHumburger();
        BindEvents();
        BindTimer();
        BindScore();
        BindGameState();
        BindHamburgerController();
        BindBalance();
    }

    private void CreateInstance()
    {
        _hamburger = new Hamburger();
        _score = new Score();
        _madeIngredients = new MadeIngredients();
        _timePlay = new TimePlay();
        _timer = new Timer(_timerBalance.Time);
        _gameLevel = new GameLevel(_levelBalance, _score);
        _recipeFactory = new RecipeFactory(_ingredients, _ingredientsInLevelBalance, _gameLevel);
        _hamburgerValid = new HamburgerValid(_recipeFactory.Create());
        _timeBetweenMadeIngredients = new TimeMadeIngredients();
        _hamburgerControllersDataRandomizer = new HamburgerControllersDataRandomizer(_ingredients, _hamburgerControllersSprites);
        _hamburgerControllersInitializerFactory = new HamburgerControllersInitializerFactory(_hamburgerControllersDataRandomizer.Data);
    }

    private void BindHumburger()
    {
        Container.BindInstance(_hamburger);
        Container.BindInstance(_hamburgerFactory);
        Container.BindInstance(_hamburgerValid);
        Container.BindInstance(_ingredients);
    }

    private void BindHamburgerController()
    {
        Container.BindInstance(_hamburgerControllersSprites);
        Container.BindInstance(_hamburgerControllersDataRandomizer);
        Container.BindInstance(_hamburgerControllersInitializerFactory);
    }

    private void BindRecipe()
    {
        Container.BindInstance(_recipeFactory);
        Container.BindInstance(_recipeGameObjectFactory);
    }

    private void BindEvents()
    {
        Container.BindInstance(_hamburgerControllerEvents);
    }

    private void BindTimer()
    {
        Container.BindInstance(_timer);
        Container.BindInstance(_tickableController);
        Container.BindInstance(_timerBalance);
    }

    private void BindScore()
    {
        Container.BindInstance(_score);
        Container.BindInstance(_timePlay);
        Container.BindInstance(_madeIngredients);
        Container.BindInstance(_timeBetweenMadeIngredients);
    }

    private void BindGameState()
    {
        Container.BindInstance(_gameState);
        Container.BindInstance(_gameLevel);
    }

    private void BindBalance()
    {
        Container.BindInstance(_hideIngredientsBalance);
        Container.BindInstances(_eventBalance);
    }
}
