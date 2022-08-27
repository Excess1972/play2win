using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [System.Serializable]
    public class LevelChangeEvent : UnityEvent<GameObject> { }

    public GameEvent Event;
    public LevelChangeEvent Response;

    public void OnEnable()
    {
        Event.RegisterListener(this);
    }

    public void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(GameObject enemy)
    {
        Response.Invoke(enemy.gameObject);
    }
}
