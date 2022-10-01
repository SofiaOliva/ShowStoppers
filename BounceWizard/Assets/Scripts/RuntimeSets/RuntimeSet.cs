using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class RuntimeSet<T> : ScriptableObject
{
    [HideInInspector] private List<T> list = new List<T>();

    public event Action RemoveEvent;
    public event Action EmptyEvent;

    public void Add(T item)
    {
        list.Add(item);
    }

    public void Remove(T item)
    {
        list.Remove(item);
        RemoveEvent?.Invoke();
        if(list.Count <= 0)
        {
            EmptyEvent?.Invoke();
        }
    }

    public T this[int index]
    {
        get => list[index];
    }

    public int Count
    {
        get
        {
            return list.Count;
        }
    }
}
