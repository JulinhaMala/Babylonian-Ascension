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
                print(actualTurn);
                actualTurn = 0;
            }
            if (actualTurn == Turn.enemy)
            {
                print(actualTurn);
                EnemyBehaviour.instance.StartEnemyTurn();
            }
            if (actualTurn == Turn.player)
            {
                print(actualTurn);
                MouseMove.canMove = true;
            }
            endedTurn = false;
        }
    }
}
