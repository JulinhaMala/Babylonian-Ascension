using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Buttons_Stats : MonoBehaviour
{
    [SerializeField] public TMP_Text Eco_Text, Mil_Text, Soci_Text, Dese_Text;
    [SerializeField] float Multi_Eco, Multi_Mil, Multi_Soci, Multi_Dese;
    [SerializeField] float IncreaseEco, IncreaseMil, IncreaseSoci, IncreaseDese;

    void Start()
    {
        IncreaseEco = 20;
        IncreaseMil = 20;
        IncreaseSoci = 20;
        IncreaseDese = 20;
        Eco_Text.text = $"Actual Increment: {Stats.instance.EconoX}" + $"Poss Increment: {Stats.instance.EconoX *= Multi_Eco}";
        Mil_Text.text = $"Actual Increment: {Stats.instance.MilitaX}" + $"Poss Increment: {Stats.instance.MilitaX *= Multi_Mil}";
        Soci_Text.text = $"Actual Increment: {Stats.instance.SocialX}" + $"Poss Increment: {Stats.instance.SocialX *= Multi_Soci}";
        Dese_Text.text = $"Actual Increment: {Stats.instance.DesenvolX}" + $"Poss Increment: {Stats.instance.DesenvolX *= Multi_Dese}";
    }

    public void Eco()
    {
        Stats.instance.Econo -= IncreaseEco;
        IncreaseEco += 2;
        Stats.instance.EconoX *= Multi_Eco;
        Eco_Text.text = $"Actual Increment: {Stats.instance.EconoX}" + $"Poss Increment: {Stats.instance.EconoX *= Multi_Eco}";
    }

    public void Mil()
    {
        Stats.instance.Milita -= IncreaseMil;
        IncreaseMil += 2;
        Stats.instance.MilitaX *= Multi_Mil;
        Mil_Text.text = $"Actual Increment: {Stats.instance.MilitaX}" + $"Poss Increment: {Stats.instance.MilitaX *= Multi_Mil}";
    }

    public void Soci()
    {
        Stats.instance.Social -= IncreaseSoci;
        IncreaseSoci += 2;
        Stats.instance.SocialX *= Multi_Soci;
        Soci_Text.text = $"Actual Increment: {Stats.instance.SocialX}" + $"Poss Increment: {Stats.instance.SocialX *= Multi_Soci}";
    }

    public void Dese()
    {
        Stats.instance.Desenvol -= IncreaseDese;
        IncreaseDese += 2;
        Stats.instance.DesenvolX *= Multi_Dese;
        Dese_Text.text = $"Actual Increment: {Stats.instance.DesenvolX}" + $"Poss Increment: {Stats.instance.DesenvolX *= Multi_Dese}";
    }

}
