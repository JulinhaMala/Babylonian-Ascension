using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public static Events instance;
    public GameObject painel;
    [Header("Eventos:")]
    [Space(20)]
    public UnityEvent Invasao;
    [Space(15)]
    public UnityEvent Escassez;
    [Space(15)]
    public UnityEvent Doenca;

    void Awake()
    {
        instance = this;
    }
}
