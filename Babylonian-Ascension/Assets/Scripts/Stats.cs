using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static Stats instance;
    public float Econo, Milita, Social, Desenvol;
    public float MaxEcono, MaxMilita, MaxSocial, MaxDesenvol;

    public void Start()
    {
        instance = this;
        MaxEcono = 100;
        MaxMilita = 100;
        MaxSocial = 100;
        MaxDesenvol = 100;
    }
}
