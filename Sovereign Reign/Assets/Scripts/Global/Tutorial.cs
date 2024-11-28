using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    public static bool hasEnded;
    public int index;

    public UnityEvent TutorialSkip;

    public UnityEvent TutorialEnd;

    public UnityEvent deactiveAll;

    public UnityEvent Phase1;
    public UnityEvent Phase2;
    public UnityEvent Phase3;
    public UnityEvent Phase4;

    void Start()
    {
        Time.timeScale = 0f;
        if (hasEnded)
        {
            TutorialSkip.Invoke();
        }
    }

    public void EndTutorial()
    {
        Time.timeScale = 1f;
        hasEnded = true;
        TutorialEnd.Invoke();
    }

    public void PassTutorial()
    {
        switch (index)
        {
            case 0:
                deactiveAll.Invoke();

                Phase1.Invoke();
                break;
            case 1:
                deactiveAll.Invoke();

                Phase2.Invoke();
                break;
            case 2:
                deactiveAll.Invoke();

                Phase3.Invoke();
                break;
            case 3:
                deactiveAll.Invoke();

                Phase4.Invoke();
                break;
            case 4:
                EndTutorial();
                break;
        }
        index++;
    }
}
