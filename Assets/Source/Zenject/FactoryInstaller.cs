using Zenject;
using UnityEngine;

public class FactoryInstaller : MonoInstaller
{
    [SerializeField] private HamburgerFactory _hamburgerFactory;
    [SerializeField] private RecipeGameObjectFactory _recipeGameObjectFactory;
    [SerializeField] private Ingredients _ingredients;
    [SerializeField] private IngredientsInLevelBalance _ingredientsBalance;
    [SerializeField] private GameLevel _level;
    [SerializeField] private HamburgerControllersData _hamburgerControllerData;
    public HamburgerControllersInitializerFactory HamburgerControllersInitializerFactory { get; private set; }
    public RecipeFactory RecipeFactory { get; private set; }

    public override void InstallBindings()
    {
        Container.BindInstance(_hamburgerFactory);
        Container.BindInstance(_recipeGameObjectFactory);
        Container.BindInstance(HamburgerControllersInitializerFactory = new HamburgerControllersInitializerFactory(_hamburgerControllerData));
        Container.BindInstance(RecipeFactory = new RecipeFactory(_ingredients, _ingredientsBalance, _level));
    }
}
