using UnityEngine;

public enum PassedEvents
{
    none, invasao, escassez, doenca
}

public class EventTimer : MonoBehaviour
{
    PassedEvents eventsPassed;

    public static EventTimer instance;
    void Awake()
    {
        instance = this;
    }
    public void AleatoryEvent()
    {
        switch (eventsPassed)
        {
            case PassedEvents.none:
                break;
            case PassedEvents.invasao:
                break;
            case PassedEvents.escassez:
                break;
            case PassedEvents.doenca:
                break;
        }
    }
}
