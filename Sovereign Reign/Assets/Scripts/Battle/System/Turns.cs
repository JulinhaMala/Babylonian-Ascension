using UnityEngine;

public enum Turn
{
    player, enviroment, enemy
}

public class Turns : MonoBehaviour
{
    public static Turn actualTurn;

    public static void PassTurn()
    {
        actualTurn++;
        if (actualTurn > Turn.enemy) 
        { 
            actualTurn = 0;
        }
    }
}
