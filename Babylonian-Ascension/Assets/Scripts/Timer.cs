using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent CanInteract;
    float time;
    int timer = 20;

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= timer)
        {
            CanInteract.Invoke();
        }
    }
}
