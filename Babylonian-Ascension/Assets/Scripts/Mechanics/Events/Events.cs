using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    [Header("Eventos:")]
    [Space(20)]

    [Header("   Invasão:")]
    [Space(15)]

    public UnityEvent Invasao;
    [Space(5)]

    [Header("       Respostas")]
    [Space(15)]


    public UnityEvent Vitoria;
    [Space(10)]
    public UnityEvent Derrota;

    [Space(20)]

    [Header("   Escassez:")]
    [Space(15)]

    public UnityEvent Escassez;
    [Space(5)]

    [Header("       Respostas")]
    [Space(15)]

    public UnityEvent Aceitacao;
    [Space(10)]
    public UnityEvent Revolta;

    [Space(20)]

    [Header("   Doença:")]
    [Space(15)]

    public UnityEvent Doenca;
    [Space(5)]

    [Header("       Respostas")]
    [Space(15)]

    public UnityEvent Cura;
    [Space(10)]
    public UnityEvent Epidemia;

    public static Events instance;
    void Awake()
    {
        instance = this;
    }
}
