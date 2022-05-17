using Zenject;
using UnityEngine;
using System;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private HamburgerFactory _hamburgerFactory;
    [SerializeField] private RecipeGameObjectFactory recipeGameObjectFactory;
    [SerializeField] private HamburgerControllersEvents _hamburgerControllerEvents;
    [SerializeField] private Ingredients _ingredients;
    [SerializeField] private ControllerSprites _controllerSprites;
    [SerializeField] private TimerBalance _timerBalance;
    [SerializeField] private LevelBalance _levelBalance;
    [SerializeField] private EventBalance _eventBalance;
    [SerializeField] private IngredientsInLevelBalance _ingredientsInLevelBalance;
    [SerializeField] private TickableController _tickableController;
    [SerializeField] GameState _gameState;

    private Hamburger _hamburger;
    private RecipeFactory _recipeFactory;
    private HamburgerValid _hamburgerValid;
    private Timer _timer;
    private MadeIngredients _madeIngredients;
    private Score _score;
    private TimePlay _timePlay;
    private TimeMadeIngredients _timeBetweenMadeIngredients;
    private GameLevel _gameLevel;
    private HamburgerControllersInitializer _hamburgerControllersInitializer;
    private HamburgerControllersDataController _hamburgerControllersDataController;

    private void OnValidate()
    {
        if (_hamburgerFactory == recipeGameObjectFactory)
        {
            enabled = false;
            throw new Exception("HamburgerFactory must != RecipeItemFactory");
        }
    }

    public override void InstallBindings()
    {
        CreateInstance();
        BindRecipe();
        BindHumburger();
        BindEvents();
        BindTimer();
        BindScore();
        BindGameState();
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
        _hamburgerControllersDataController = new HamburgerControllersDataController(_ingredients , _controllerSprites);
        _hamburgerControllersInitializer = new HamburgerControllersInitializer(_hamburgerControllersDataController.Data);
    }

    private void BindHumburger()
    {
        Container.BindInstance(_hamburger);
        Container.BindInstance(_hamburgerFactory);
        Container.BindInstance(_hamburgerValid);
        Container.BindInstance(_ingredients);
        Container.BindInstance(_controllerSprites);
        Container.BindInstance(_hamburgerControllersDataController);
        Container.BindInstance(_hamburgerControllersInitializer);
    }

    private void BindRecipe()
    {
        Container.BindInstance(_recipeFactory);
        Container.BindInstance(recipeGameObjectFactory);
    }

    private void BindEvents()
    {
        Container.BindInstance(_hamburgerControllerEvents);
        Container.BindInstances(_eventBalance);
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
}
