using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemsList : MonoBehaviour
{
    [SerializeField] private BreadDownItem _breadDownItem;
    [SerializeField] private BreadUpItem _breadUpItem;
    [SerializeField] private CheaseItem _cheaseItem;
    [SerializeField] private GreenItem _greenItem;
    [SerializeField] private HealmanthItem _healmanthItem;
    [SerializeField] private KetchupItem _ketchupItem;
    [SerializeField] private MeatItem _meatItem;

    public List<Item> GetList()
    {
        return new List<Item>()
        {
            _breadDownItem,
            _breadUpItem,
            _cheaseItem,
            _greenItem,
            _healmanthItem,
            _ketchupItem,
            _meatItem
         };
    }

    public Item Find(Item item)
    {
        var items = GetList();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetType() == item.GetType())
                return items[i];
        }

        throw new InvalidOperationException("itemList dont contain " + item.GetType());
    }
}
