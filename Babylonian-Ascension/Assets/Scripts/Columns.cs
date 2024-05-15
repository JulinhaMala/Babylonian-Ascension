using System.Collections;
using System.Collections.Generic;
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
        ColuEco.fillAmount = Stats.instance.Econo / Stats.instance.MaxEcono;
        if ((Stats.instance.Econo / Stats.instance.MaxEcono) <= 0.1)
        {
            ColuEco.fillAmount = 0.1f;
        }
    }
    public void MilSet()
    {
        ColuMil.fillAmount = Stats.instance.Milita / Stats.instance.MaxMilita;
        if ((Stats.instance.Milita / Stats.instance.MaxMilita) <= 0.1)
        {
            ColuMil.fillAmount = 0.1f;
        }
    }
    public void SociSet()
    {
        ColuSoci.fillAmount = Stats.instance.Social / Stats.instance.MaxSocial;
        if ((Stats.instance.Social / Stats.instance.MaxSocial) <= 0.1)
        {
            ColuSoci.fillAmount = 0.1f;
        }
    }
    public void DeseSet()
    {
        ColuDese.fillAmount = Stats.instance.Desenvol / Stats.instance.MaxDesenvol;
        if ((Stats.instance.Desenvol / Stats.instance.MaxDesenvol) <= 0.1)
        {
            ColuDese.fillAmount = 0.1f;
        }
    }

    
    public void EcoText()
    {
        Eco_Text.text = $" {Stats.instance.Econo} / {Stats.instance.MaxEcono}";
    }
    public void MilText()
    {
        Mil_Text.text = $"{Stats.instance.Milita} / {Stats.instance.MaxMilita}";
    }
    public void SociText()
    {
        Soci_Text.text = $"{Stats.instance.Social} / {Stats.instance.MaxSocial}";
    }
    public void DeseText()
    {
        Dese_Text.text = $"{Stats.instance.Desenvol} / {Stats.instance.MaxDesenvol}";
    }
    
}
