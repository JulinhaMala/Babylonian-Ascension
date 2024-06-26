using UnityEngine;
using UnityEngine.Events;

public class ConsillTimer : MonoBehaviour
{
    public int timer = 5;
    public UnityEvent SetActive;
    float time;

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
