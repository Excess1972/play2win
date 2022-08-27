using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Neues GameEvent", menuName = "Game Event", order = 0)]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> _events = new List<GameEventListener>();

    public void Raise(GameObject enemy)
    {
        for (int i = _events.Count -1; i >= 0; i--)
        {
            _events[i].OnEventRaised(enemy);
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        _events.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        _events.Remove(listener);
    }
}
