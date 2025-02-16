using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private Dictionary<string, Action> events = new Dictionary<string, Action>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void TriggerEvent(string eventName)
    {
        if (events.ContainsKey(eventName))
        {
            events[eventName]?.Invoke();
        }
    }

    public void RegisterEvent(string eventName, Action action)
    {
        if (!events.ContainsKey(eventName))
        {
            events.Add(eventName, action);
        }
    }
}
