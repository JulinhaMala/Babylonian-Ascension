using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Columns : MonoBehaviour
{
    [SerializeField] public Image ColuEco, ColuMil, ColuSoci, ColuDese;
    [SerializeField] public TMP_Text Eco_Text, Mil_Text, Soci_Text, Dese_Text;

    private void FixedUpdate()
    {
        AllSet();
    }

    public void AllSet()
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

    public void EcoSet()
    {
        ColuEco.fillAmount = Stats.instance.econo / Stats.instance.maxEcono;
        if ((Stats.instance.econo / Stats.instance.maxEcono) <= 0.1)
        {
            ColuEco.fillAmount = 0.1f;
        }
    }
    public void MilSet()
    {
        ColuMil.fillAmount = Stats.instance.milita / Stats.instance.maxMilita;
        if ((Stats.instance.milita / Stats.instance.maxMilita) <= 0.1)
        {
            ColuMil.fillAmount = 0.1f;
        }
    }
    public void SociSet()
    {
        ColuSoci.fillAmount = Stats.instance.social / Stats.instance.maxSocial;
        if ((Stats.instance.social / Stats.instance.maxSocial) <= 0.1)
        {
            ColuSoci.fillAmount = 0.1f;
        }
    }
    public void DeseSet()
    {
        ColuDese.fillAmount = Stats.instance.desenvol / Stats.instance.maxDesenvol;
        if ((Stats.instance.desenvol / Stats.instance.maxDesenvol) <= 0.1)
        {
            ColuDese.fillAmount = 0.1f;
        }
    }

    
    public void EcoText()
    {
        Eco_Text.text = $" {Stats.instance.econo} / {Stats.instance.maxEcono}";
    }
    public void MilText()
    {
        Mil_Text.text = $"{Stats.instance.milita} / {Stats.instance.maxMilita}";
    }
    public void SociText()
    {
        Soci_Text.text = $"{Stats.instance.social} / {Stats.instance.maxSocial}";
    }
    public void DeseText()
    {
        Dese_Text.text = $"{Stats.instance.desenvol} / {Stats.instance.maxDesenvol}";
    }
    
}
