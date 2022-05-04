using UnityEngine;
using Zenject;

public class MadeItemsController : MonoBehaviour
{
    [Inject] private MadeItems _madeItems;

    public void Increase()
    {
        _madeItems.IncreaseMadeItems();
    }
}
