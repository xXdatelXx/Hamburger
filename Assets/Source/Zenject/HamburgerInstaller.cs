using UnityEngine;
using Zenject;

public class HamburgerInstaller : MonoInstaller
{
    [SerializeField] private HamburgerControllersSprites _hamburgerControllersSprites;
    [SerializeField] private HamburgerControllersEvents _hamburgerControllerEvents;
    [SerializeField] private public HamburgerControllersDataRandomizer HamburgerControllersDataRandomizer { get; private set; }
    private HamburgerValid HamburgerValid { get; private set; }
    public HamburgerControllersSprites HamburgerControllersSprites => _hamburgerControllersSprites;

    [Inject]
    private void Construct(Recipe recipe, Ingredients ingredients)
    {
        HamburgerValid = new HamburgerValid(recipe);
        HamburgerControllersDataRandomizer = new HamburgerControllersDataRandomizer(ingredients, _hamburgerControllersSprites);
    }

    public override void InstallBindings()
    {
        Container.BindInstance(new Hamburger());
        Container.BindInstance(HamburgerControllersDataRandomizer);
        Container.BindInstance(HamburgerValid);
        Container.BindInstance(_hamburgerControllersSprites);
        Container.BindInstance(_hamburgerControllerEvents);
    }
}
