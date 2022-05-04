using System.Collections.Generic;
using System;

// Нада шоб не могли добавить null
public abstract class ItemsCollection
{
    private List<Item> _items = new List<Item>();
    public IReadOnlyList<Item> Items => _items;
    public int ItemCount => _items.Count;

    public Item this[int index] => _items[index];

    public void Add(Item item)
    {
        if (Valid(item))
            _items.Add(item);
    }

    public void Insert(int index, Item item)
    {
        if (Valid(item))
            _items.Insert(index, item);
    }

    public void RemoveAll()
    {
        _items = new List<Item>();
    }

    public void Set(int id, Item item)
    {
        if (Valid(item))
            _items[id] = item;
    }

    public Item Find(Predicate<Item> item)
    {
        return _items.Find(item);
    }

    private bool Valid(Item item)
    {
        if (item is null)
            throw new NullReferenceException("entity on add == null");

        return true;
    }
}
