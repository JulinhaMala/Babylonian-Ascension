using UnityEngine;

public enum Turn
{
    player, enemy
}

public class Turns : MonoBehaviour
{
    public static Turn actualTurn;
    public static bool endedTurn;

    public static void PassTurn()
    {
        if(endedTurn)
        {
            actualTurn++;
            if (actualTurn > Turn.enemy)
            {
                actualTurn = 0;
            }
            endedTurn = false;
            if (actualTurn == Turn.enemy)
            {
                EnemyBehaviour.instance.StartEnemyTurn();
            }
            if (actualTurn == Turn.player)
            {
                MouseMove.canMove = true;
            }
        }
    }
}
