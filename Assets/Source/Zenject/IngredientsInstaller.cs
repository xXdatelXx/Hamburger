using Zenject;
using UnityEngine;

public class IngredientsInstaller : MonoInstaller
{
    [SerializeField] private Ingredients _ingredients;
    public Ingredients Ingredients => _ingredients;

    public override void InstallBindings()
    {
        Container.BindInstance(_ingredients);
    }
}
