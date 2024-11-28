using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    public int index;

    public UnityEvent deactiveAll;

    public UnityEvent trade1;

    public UnityEvent colluns1;


    public void PassTutorial()
    {
        switch (index)
        {
            case 0:
                deactiveAll.Invoke();

                trade1.Invoke();
                break;
            case 1:
                deactiveAll.Invoke();

                colluns1.Invoke();
                break;
            case 2:
                deactiveAll.Invoke();

                trade1.Invoke();
                break;
            case 3:
                deactiveAll.Invoke();

                trade1.Invoke();
                break;
            case 4:
                deactiveAll.Invoke();

                trade1.Invoke();
                break;
            case 5:
                deactiveAll.Invoke();

                deactiveAll.Invoke();
                break;
            case 6:
                deactiveAll.Invoke();

                deactiveAll.Invoke();
                break;
            case 7:
                deactiveAll.Invoke();

                deactiveAll.Invoke();
                break;
            case 8:
                deactiveAll.Invoke();

                deactiveAll.Invoke();
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
        }
        index++;
    }
}
