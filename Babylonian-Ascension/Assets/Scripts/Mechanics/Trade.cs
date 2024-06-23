using UnityEngine;

enum Add
{
    eco, mil, soc, des
}
enum Sub
{
    eco, mil, soc, des
}

public class Trade : MonoBehaviour
{
    public static Trade instance;
    [SerializeField] float Increase;
    Add addStat;
    Sub subStat;
    public int timesUsed;

    void Awake()
    {
        instance = this;
        Increase = 5;
    }
    public void SelectQuant(int index)
    {
        switch (index)
        {
            case 0:
                Increase = 5;
                break;

            case 1:
                Increase = 10;
                break;

            case 2:
                Increase = 15;
                break;
            default:
                Increase = 5;
                break;
        }
    }
    public void SelectAdditional(int index)
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
    public void SelectFont(int index)
    {
        switch (index)
        {
            case 0:
                subStat = Sub.eco;
                break;

            case 1:
                subStat = Sub.mil;
                break;

            case 2:
                subStat = Sub.soc;
                break;

            case 3:
                subStat = Sub.des;
                break;
        }
    }

    public void Math()
    {
        if(timesUsed >= 3)
        {
            return;
        }

        #region Verify If they are the same
        if (addStat == Add.eco && subStat == Sub.eco) 
        {
            return;
        }
        else if (addStat == Add.mil && subStat == Sub.mil)
        {
            return;
        }
        else if (addStat == Add.soc && subStat == Sub.soc)
        {
            return;
        }
        else if (addStat == Add.des && subStat == Sub.des)
        {
            return;
        }
        #endregion

        timesUsed++;

        switch (addStat)
        {
            case Add.eco:
                Stats.instance.econo += Increase;
                break;

            case Add.mil:
                Stats.instance.milita += Increase;
                break;

            case Add.soc:
                Stats.instance.social += Increase;
                break;

            case Add.des:
                Stats.instance.desenvol += Increase;
                break;
        }
        switch (subStat)
        {
            case Sub.eco:
                Stats.instance.econo -= Increase;
                break;

            case Sub.mil:
                Stats.instance.milita -= Increase;
                break;

            case Sub.soc:
                Stats.instance.social -= Increase;
                break;

            case Sub.des:
                Stats.instance.desenvol -= Increase;
                break;
        }
    }
}
