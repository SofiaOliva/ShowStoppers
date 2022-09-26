using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "EventSO", menuName = "EventsSO/Void", order = 1)]
public class EventSO : ScriptableObject
{
    public event Action Event;
    [SerializeField] string description;

    public void Trigger()
    {
        Event?.Invoke();
    }
}

//[CreateAssetMenu(fileName = "EventSO", menuName = "EventsSO/T", order = 1)]
public class EventSO<T> : ScriptableObject
{
    public event Action<T> Event;
    [SerializeField] string description;

    public void Trigger(T t)
    {
        Event?.Invoke(t);
    }
}
