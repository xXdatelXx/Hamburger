using System.Collections.Generic;
using UnityEngine;

public class CompositeOrder : MonoBehaviour
{
    [SerializeField] private List<CompositeRoot> _order;

    private void Awake()
    {
        foreach (var compositionRoot in _order)
        {
            compositionRoot.Compose();
            compositionRoot.enabled = true;
        }
    }
}
