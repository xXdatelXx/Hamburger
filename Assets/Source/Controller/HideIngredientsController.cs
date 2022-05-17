using UnityEngine;
using System;
using Zenject;
using Random = UnityEngine.Random;

public class HideIngredientsController : MonoBehaviour
{
    [SerializeField] private HideIngredientsBalance _balance;
    private HamburgerControllersDataController _hamburgerControllersDataController;
    private GameLevel _level;

    [Inject]
    private void Construct(HamburgerControllersDataController data, GameLevel level)
    {
        _hamburgerControllersDataController = data;
        _level = level;
    }

    public void Hide()
    {
        int hidesIngredient = _level.GetGameLevel() switch
        {
            Level.First => _balance.HideIngredientsInLevel1,
            Level.Second => _balance.HideIngredientsInLevel2,
            Level.Third => _balance.HideIngredientsInLevel3,
            Level.Fourth => _balance.HideIngredientsInLevel4,
            Level.Max => _balance.HideIngredientsInLevelMax,
            _ => throw new InvalidOperationException()
        };

        bool hide = Random.Range(0, 100) < _balance.PercentToHide;

        if (hide)
            _hamburgerControllersDataController.RandomizeHidesId(hidesIngredient);
    }
}
