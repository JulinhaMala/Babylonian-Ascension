using UnityEngine;

public class Stats : MonoBehaviour
{
    public static Stats instance;

    public GameObject fim;

    public float econo, milita, social, desenvol;
    public float maxEcono, maxMilita, maxSocial, maxDesenvol;
    public float econoX, militaX, socialX, desenvolX;

    [SerializeField] int timeToPassDay = 20;
    float actualTime;

    public void Start()
    {
        instance = this;
        Max();
        Inicio();
        Increase();
    }

    #region StartStatistics
    public void Max()
    {
        maxEcono = 100; maxMilita = 100; maxSocial = 100; maxDesenvol = 100;
    }

    public void Inicio()
    {
        econo = 25; milita = 25; social = 25; desenvol = 25;
    }

    public void Increase()
    {
        econoX = 3; militaX = 3; socialX = 3; desenvolX = 3;
    }
    #endregion

    private void FixedUpdate()
    {
        actualTime += Time.deltaTime;
        if (actualTime >= timeToPassDay) 
        {
            print("StatsUP");
            econo += econoX;
            milita += militaX;
            social += socialX;
            desenvol += desenvolX;
            Days.instance.PassDay();
            actualTime = 0;
        }
        if (econo <= 0 || milita <= 0 || social <= 0 || desenvol <= 0)
        {
            fim.SetActive(true);
            Time.timeScale = 0;
        }
        #region Max
        if (econo >= maxEcono)
        {
            econo = maxEcono;
        }
        if(milita >= maxMilita)
        {
            milita = maxMilita;
        }
        if (social >= maxSocial)
        {
            social = maxSocial;
        }
        if (desenvol >= maxDesenvol)
        {
            desenvol = maxDesenvol;
        }
        #endregion
    }
}
