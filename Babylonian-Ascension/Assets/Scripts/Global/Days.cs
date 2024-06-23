using System.Collections;
using UnityEngine;
using TMPro;
public class Days : MonoBehaviour
{
    public static Days instance;
    public int currentDay, daysPassed;
    [SerializeField] TMP_Text days_Txt;
    [SerializeField] GameObject passDayAnim;

    private void Awake()
    {
        instance = this;
        passDayAnim.SetActive(false);
        currentDay = 1;
        days_Txt.text = $"Você está no: Dia {currentDay}";
    }
    public void PassDay()
    {
        EventsButtons.instance.curentTime = 0;
        daysPassed++;
        currentDay++;
        days_Txt.text = $"Você está no: Dia {currentDay}";
        Trade.instance.timesUsed = 0;
        passDayAnim.SetActive(true);
    }
    public void DeactivateAnim()
    {
        passDayAnim.SetActive(false);
    }
}
