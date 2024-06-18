using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static Stats instance;

    public GameObject Fim;

    public float Econo, Milita, Social, Desenvol;
    public float MaxEcono, MaxMilita, MaxSocial, MaxDesenvol;
    public float EconoX, MilitaX, SocialX, DesenvolX;

    float time;
    int timer = 20;

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
        MaxEcono = 100; MaxMilita = 100; MaxSocial = 100; MaxDesenvol = 100;
    }

    public void Inicio()
    {
        Econo = 25; Milita = 25; Social = 25; Desenvol = 25;
    }

    public void Increase()
    {
        EconoX = 1; MilitaX = 1; SocialX = 1; DesenvolX = 1;
    }
    #endregion

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= timer) 
        {
            Econo += EconoX;
            Milita += MilitaX;
            Social += SocialX;
            Desenvol += DesenvolX;
            time = 0;
        }
        if (Econo <= 0 || Milita <= 0 || Social <= 0 || Desenvol <= 0)
        {
            Fim.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
