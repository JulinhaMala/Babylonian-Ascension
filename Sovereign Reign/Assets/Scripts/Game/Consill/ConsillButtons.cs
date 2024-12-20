using UnityEngine;
using TMPro;
using UnityEditor;

public class ConsillButtons : MonoBehaviour
{
    public int caso;
    int casoAnt;
    public void Aleatorizate(TMP_Text button)
    {
        caso = Random.Range(1, 12);
        while (caso == casoAnt)
        {
            caso = Random.Range(1, 12);
        }
        casoAnt = caso;
        switch (caso)
        {
            #region Economia
            case 1:
                button.text = "Economia + / Militar -";
                break;
            case 2:
                button.text = "Economia + / Social -";
                break;
            case 3:
                button.text = "Economia + / Pesquisa -";
                break;
            #endregion
            #region Militar
            case 4:
                button.text = "Militar + / Economia -";
                break;
            case 5:
                button.text = "Militar + / Social -";
                break;
            case 6:
                button.text = "Militar + / Pesquisa -";
                break;
            #endregion
            #region Social
            case 7:
                button.text = "Social + / Economia -";
                break;
            case 8:
                button.text = "Social + / Militar -";
                break;
            case 9:
                button.text = "Social + / Pesquisa -";
                break;
    #endregion
            #region Desenvolvimento
            case 10:
                button.text = "Pesquisa + / Economia -";
                break;
            case 11:
                button.text = "Pesquisa + / Militar -";
                break;
            case 12:
                button.text = "Pesquisa + / Social -";
                break;
    #endregion
        }
    }
    void Calculate(int caso)
    {
        switch (caso)
        {
            #region Economia
            case 1:
                Stats.instance.econoX += 0.2f;

                Stats.instance.militaX -= 0.2f;

                break;
            case 2:
                Stats.instance.econoX += 0.2f;

                Stats.instance.socialX -= 0.2f;

                break;
            case 3:
                Stats.instance.econoX += 0.2f;

                Stats.instance.desenvolX -= 0.2f;

                break;
            #endregion
            #region Militar
            case 4:
                Stats.instance.militaX += 0.2f;

                Stats.instance.econoX -= 0.2f;

                break;
            case 5:
                Stats.instance.militaX += 0.2f;

                Stats.instance.socialX -= 0.2f;

                break;
            case 6:
                Stats.instance.militaX += 0.2f;

                Stats.instance.desenvolX -= 0.2f;

                break;
            #endregion
            #region Social
            case 7:
                Stats.instance.socialX += 0.2f;

                Stats.instance.econoX -= 0.2f;
                break;
            case 8:
                Stats.instance.socialX += 0.2f;

                Stats.instance.militaX -= 0.2f;
                break;
            case 9:
                Stats.instance.socialX += 0.2f;

                Stats.instance.desenvolX -= 0.2f;
                break;
            #endregion
            #region Desenvolvimento
            case 10:
                Stats.instance.desenvolX += 0.2f;

                Stats.instance.econoX -= 0.2f;
                break;
            case 11:
                Stats.instance.desenvolX += 0.2f;

                Stats.instance.militaX -= 0.2f;
                break;
            case 12:
                Stats.instance.desenvolX += 0.2f;

                Stats.instance.socialX -= 0.2f;
                break;
                #endregion
        }
    }
    public void Button()
    {
        Calculate(caso);
    }
}
