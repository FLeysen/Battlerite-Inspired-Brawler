using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private List<Observer> _observers = new List<Observer>();

    public void AddObserver(Observer observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        _observers.Remove(observer);
    }

    public void Notify<T, Y>(T source, int eventIndex, params Y[] args)
    {
        foreach (Observer observer in _observers)
        {
            observer.OnNotify(source, eventIndex, args);
        }
    }
}
