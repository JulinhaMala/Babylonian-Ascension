using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public enum Add
{
    eco, mil, soc, des
}
public enum Subtract
{
    eco, mil, soc, des
}

public class Buttons_Stats : MonoBehaviour
{
    [SerializeField] public TMP_Text Eco_Text, Mil_Text, Soci_Text, Dese_Text;
    [SerializeField] float Multi_Eco, Multi_Mil, Multi_Soci, Multi_Dese;
    [SerializeField] float IncreaseEco, IncreaseMil, IncreaseSoci, IncreaseDese;
    Add addStat;
    Subtract subStat;

    void Start()
    {
        IncreaseEco = 5;
        IncreaseMil = 5;
        IncreaseSoci = 5;
        IncreaseDese = 5;
        Eco_Text.text = $"";
        Mil_Text.text = $"";
        Soci_Text.text = $"";
        Dese_Text.text = $"";
    }

    public void SelectFont(int index)
    {
        switch (index)
        {
            case 0:
                addStat = Add.eco;
                break;

            case 1:
                addStat = Add.mil;
                break;

            case 2:
                addStat = Add.soc;
                break;

            case 3:
                addStat = Add.des;
                break;
        }
    }

    public void SelectAdditional(int index)
    {
        switch (index)
        {
            case 0:
                subStat = Subtract.eco;
                break;

            case 1:
                subStat = Subtract.mil;
                break;

            case 2:
                subStat = Subtract.soc;
                break;

            case 3:
                subStat = Subtract.des;
                break;
        }
    }

    public void Math()
    {
        switch (addStat)
        {
            case Add.eco:

                break;

            case Add.mil:

                break;

            case Add.soc:

                break;

            case Add.des:

                break;
        }
        switch (subStat)
        {
            case Subtract.eco:

                break;

            case Subtract.mil:

                break;

            case Subtract.soc:

                break;

            case Subtract.des:

                break;
        }
    }
}
