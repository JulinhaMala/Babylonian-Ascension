using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Columns : MonoBehaviour
{
    [SerializeField] public Image ColuEco, ColuMil, ColuSoci, ColuDese;
    [SerializeField] public TMP_Text Eco_Text, Mil_Text, Soci_Text, Dese_Text;

    private void Update()
    {
        EcoSet();
        MilSet();
        SociSet();
        DeseSet();
        EcoText();
        MilText();
        SociText();
        DeseText();
    }

    void EcoSet()
    {
        ColuEco.fillAmount = Stats.instance.econo / Stats.instance.maxEcono;
        if ((Stats.instance.econo / Stats.instance.maxEcono) <= 0.1)
        {
            ColuEco.fillAmount = 0.1f;
        }
    }
    void MilSet()
    {
        ColuMil.fillAmount = Stats.instance.milita / Stats.instance.maxMilita;
        if ((Stats.instance.milita / Stats.instance.maxMilita) <= 0.1)
        {
            ColuMil.fillAmount = 0.1f;
        }
    }
    void SociSet()
    {
        ColuSoci.fillAmount = Stats.instance.social / Stats.instance.maxSocial;
        if ((Stats.instance.social / Stats.instance.maxSocial) <= 0.1)
        {
            ColuSoci.fillAmount = 0.1f;
        }
    }
    void DeseSet()
    {
        ColuDese.fillAmount = Stats.instance.desenvol / Stats.instance.maxDesenvol;
        if ((Stats.instance.desenvol / Stats.instance.maxDesenvol) <= 0.1)
        {
            ColuDese.fillAmount = 0.1f;
        }
    }

    
    void EcoText()
    {
        Eco_Text.text = $" {(int)Stats.instance.econo} / {Stats.instance.maxEcono}";
    }
    void MilText()
    {
        Mil_Text.text = $"{(int)Stats.instance.milita} / {Stats.instance.maxMilita}";
    }
    void SociText()
    {
        Soci_Text.text = $"{(int)Stats.instance.social} / {Stats.instance.maxSocial}";
    }
    void DeseText()
    {
        Dese_Text.text = $"{(int)Stats.instance.desenvol} / {Stats.instance.maxDesenvol}";
    }
    
}
