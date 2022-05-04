using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoBehaviourFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private List<T> _entities = new List<T>();
    public int EntitiesCount => _entities.Count;

    public T Create(T entity)
    {
        if (entity is null)
            throw new NullReferenceException("entity on create == null");

        var newEntity = Instantiate(entity, _parent);
        SetPosition(newEntity.GetComponent<T>());

        _entities.Add(newEntity);

        return newEntity;
    }

    public void DestroyAll()
    {
        for (int i = 0; i < _entities.Count; i++)
            Destroy(_entities[i].gameObject);

        _entities = new List<T>();
    }

    protected abstract void SetPosition(T entity);
}
