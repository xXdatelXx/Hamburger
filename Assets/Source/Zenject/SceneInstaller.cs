using Zenject;
using UnityEngine;
using System;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private HamburgerFactory _hamburgerFactory;
    [SerializeField] private RecipeItemFactory _recipeItemFactory;
    [SerializeField] private HamburgerControllersEvents _hamburgerControllerEvents;
    [SerializeField] private ItemsList _itemsList;
    [SerializeField] private ItemImages _itemImages;
    [SerializeField] private TimerBalance _timerBalance;
    [SerializeField] private LevelBalance _levelBalance;
    [SerializeField] private EventBalance _eventBalance;
    [SerializeField] private ItemsInLevelBalance _itemsInLevelBalance;
    [SerializeField] private TickableController _tickableController;
    [SerializeField] GameState _gameState;

    private Hamburger _hamburger;
    private RecipeFactory _recipeFactory;
    private HamburgerValid _hamburgerValid;
    private Timer _timer;
    private MadeItems _madeItems;
    private Score _score;
    private TimePlay _timePlay;
    private TimeMadeItems _timeBetweenMadeItems;

    private void OnValidate()
    {
        if (_hamburgerFactory == _recipeItemFactory)
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
        _madeItems = new MadeItems();
        _timePlay = new TimePlay();
        _timer = new Timer(_timerBalance.Time);
        _recipeFactory = new RecipeFactory(_itemsList, _itemsInLevelBalance, new GameLevel(_levelBalance, _score));
        _hamburgerValid = new HamburgerValid(_recipeFactory.Create());
        _timeBetweenMadeItems = new TimeMadeItems();
    }

    private void BindHumburger()
    {
        Container.BindInstance(_hamburger);
        Container.BindInstance(_hamburgerFactory);
        Container.BindInstance(_hamburgerValid);
        Container.BindInstance(_itemsList);
        Container.BindInstance(_itemImages);
    }

    private void BindRecipe()
    {
        Container.BindInstance(_recipeFactory);
        Container.BindInstance(_recipeItemFactory);
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
        Container.BindInstance(_madeItems);
        Container.BindInstance(_timeBetweenMadeItems);
    }

    private void BindGameState()
    {
        Container.BindInstance(_gameState);
    }
}
