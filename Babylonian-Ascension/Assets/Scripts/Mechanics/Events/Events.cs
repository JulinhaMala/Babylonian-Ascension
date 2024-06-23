using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Events : MonoBehaviour
{
    public GameObject painel;
    public TMP_Text eventos, button1, button2, button3;
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
    public void SetText(string text)
    {
        eventos.text = text;
    }
    public void SetTextB1(string text)
    {
        button1.text = text;
    }
    public void SetTextB2(string text)
    {
        button2.text = text;
    }
    public void SetTextB3(string text)
    {
        button3.text = text;
    }
}
