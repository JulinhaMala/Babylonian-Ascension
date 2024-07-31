using UnityEngine;
using UnityEngine.Events;

public class EventTimer : MonoBehaviour
{
    public static EventTimer instance;
    public int timer;
    public UnityEvent SetActive;
    public float time;

    void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= timer)
        {
            SetActive.Invoke();
        }
    }
    public void Reset()
    {
        time = 0;
    }
    public void StopTime()
    {
        Time.timeScale = 0;
    }
    public void UnstopTime()
    {
        Time.timeScale = 1;
    }
}
