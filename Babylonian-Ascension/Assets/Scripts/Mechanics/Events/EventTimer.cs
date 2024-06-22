using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PassedEvents
{
    none, invasao, escassez, doenca
}

public class EventTimer : MonoBehaviour
{
    public TMP_Text explain_Text;
    public TMP_Text option1, option2, option3;

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
        }
    }
}
