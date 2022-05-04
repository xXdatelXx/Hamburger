using System.Collections.Generic;
using UnityEngine;

public abstract class UnityDictionary<TKey, TValue> : MonoBehaviour
{
    [SerializeField] private List<TKey> _key;
    public IReadOnlyList<TKey> Key => _key;

    [SerializeField] private List<TValue> _value;
    public IReadOnlyList<TValue> Value => _value;

    public int Count => _key.Count;

    public TValue this[int index]
    {
        get => Value[index];
        set => _value[index] = value;
    }

    private void OnValidate()
    {
        if (_key == null || _value == null)
            return;

        if (_key.Count < _value.Count)
        {
            int c = _value.Count - _key.Count;
            for (int i = 0; i < c; i++)
                _key.Add(default(TKey));
        }
        if (_key.Count > _value.Count)
        {
            int c = _key.Count - _value.Count;
            for (int i = 0; i < c; i++)
                _key.RemoveAt(_key.Count - 1);
        }
    }

    public void Add(TKey key, TValue value)
    {
        _key.Add(key);
        _value.Add(value);
    }

    public void Clear()
    {
        _key = null;
        _value = null;
    }

    public void Clear(int index)
    {
        _key.RemoveAt(index);
        _value.RemoveAt(index);
    }

    public void Clear(TKey key)
    {
        _value.RemoveAt(_key.IndexOf(key));
        _key.Remove(key);
    }

    public void Clear(TValue value)
    {
        _key.RemoveAt(_value.IndexOf(value));
        _value.Remove(value);
    }

    public void Clear(int index, int count)
    {
        _key.RemoveRange(index, count);
        _value.RemoveRange(index, count);
    }

    public bool ContainsValue(TValue value)
    {
        return _value.Contains(value);
    }

    public bool ContainsKey(TKey value)
    {
        return _key.Contains(value);
    }
}
