using UnityEngine;
using Zenject;

public class MadeIngredientsController : MonoBehaviour
{
    [Inject] private MadeIngredients _madeIngredients;

    public void Increase()
    {
        _madeIngredients.IncreaseMadeItems();
    }
}
