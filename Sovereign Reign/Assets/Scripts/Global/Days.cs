using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Days : MonoBehaviour
{
    public static Days instance;
    public int currentDay, daysPassed;
    [SerializeField] TMP_Text days_Txt;
    [SerializeField] GameObject passDayAnim;
    [SerializeField] int daysUntilInvasion;
    [SerializeField] TMP_Text invasionDays_Txt;


    private void Awake()
    {
        instance = this;
        passDayAnim.SetActive(false);
        currentDay = 1;
        days_Txt.text = $"Você está no dia {currentDay}";
        invasionDays_Txt.text = $"Faltam {daysUntilInvasion} dias até a invasão";
    }
    public void PassDay()
    {
        EventsButtons.instance.curentTime = 0;
        Trade.instance.Reset();
        daysPassed++;
        currentDay++;
        days_Txt.text = $"Você está no dia {currentDay}";
        passDayAnim.SetActive(true);
        daysUntilInvasion--;
        invasionDays_Txt.text = $"Faltam {daysUntilInvasion} dias até a invasão";
        if ( daysUntilInvasion < 0 )
        {
            SceneManager.LoadScene("Battle");
            daysUntilInvasion = 3;
        }
    }
    public void DeactivateAnim()
    {
        passDayAnim.SetActive(false);
    }
}
