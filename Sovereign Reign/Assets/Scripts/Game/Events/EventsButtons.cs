using UnityEngine;

public enum CurrentEvent
{
    invasao, escassez, doenca
}
public class EventsButtons : MonoBehaviour
{
    public static EventsButtons instance;
    [SerializeField] int time;
    public float curentTime;
    public CurrentEvent currentEvent;
    public void Awake()
    {
        instance = this;
    }

    public void Event(int button)
    {
        switch (currentEvent)
        {
            case CurrentEvent.invasao:
                ButtonInv(button);
                break;
            case CurrentEvent.escassez:
                ButtonEsc(button);
                break;
            case CurrentEvent.doenca:
                ButtonDoe(button);
                break;
        }
    }
    #region Buttons
    void ButtonInv(int button)
    {
        switch (button)
        {
            case 1:
                Stats.instance.social += 10;
                Stats.instance.milita -= 5;
                Stats.instance.econo -= 5;
                break;
            case 2:
                Stats.instance.social += 5;
                Stats.instance.econo -= 5;
                break;
            case 3:
                Stats.instance.social -= 10;
                Stats.instance.milita -= 5;
                break;
        }
    }
    void ButtonEsc(int button)
    {
        switch (button)
        {
            case 1:
                Stats.instance.social += 10;
                Stats.instance.econo -= 10;
                break;
            case 2:
                Stats.instance.social += 5;
                Stats.instance.econo -= 5;
                break;
            case 3:
                Stats.instance.social -= 10;
                break;
        }
    }
    void ButtonDoe(int button)
    {
        switch (button)
        {
            case 1:
                Stats.instance.social += 5;
                Stats.instance.desenvol += 5;
                Stats.instance.econo -= 10;
                break;
            case 2:
                Stats.instance.desenvol += 5;
                Stats.instance.econo -= 5;
                break;
            case 3:
                Stats.instance.social -= 5;
                Stats.instance.desenvol -= 5;
                break;
        }
    }
    public void Exit()
    {
        Time.timeScale = 1;
        EventTimer.instance.time = 0;
        Events.instance.painel.SetActive(false);
    }

    #endregion
    public void RandomEvent()
    {
        Time.timeScale = 0;
        int i = Random.Range(1, 3);
        switch (i)
        {
            case 1:
                currentEvent = CurrentEvent.invasao;
                Events.instance.Invasao.Invoke();
                break;
            case 2:
                currentEvent = CurrentEvent.escassez;
                Events.instance.Escassez.Invoke();
                break;
            case 3:
                currentEvent = CurrentEvent.doenca;
                Events.instance.Doenca.Invoke();
                break;
        }
    }
}
