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
        days_Txt.text = $"Você está no dia {currentDay}";
    }
    public void PassDay()
    {
        daysPassed++;
        currentDay++;
        days_Txt.text = $"Você está no dia {currentDay}";
        passDayAnim.SetActive(true);
    }
    public void DeactivateAnim()
    {
        passDayAnim.SetActive(false);
    }
}
