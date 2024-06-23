using UnityEngine;

public class EventTimer : MonoBehaviour
{
    
    public static EventTimer instance;
    void Start()
    {
        instance = this;
    }
    
    
}
