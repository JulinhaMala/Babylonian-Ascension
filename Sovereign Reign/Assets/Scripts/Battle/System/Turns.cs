using UnityEngine;

public enum Turn
{
    player, enemy
}

public class Turns : MonoBehaviour
{
    public static Turn actualTurn;
    public static bool endedTurn;

    public static Turns instance;

    public void Awake()
    {
        instance = this;
    }
    public void PassTurn()
    {
        if(endedTurn)
        {
            endedTurn = false;
            actualTurn++;

            if (actualTurn > Turn.enemy)
            {
                actualTurn = Turn.player;
            }

            
            if (actualTurn == Turn.enemy)
            {
                EnemyBehaviour.instance.StartEnemyTurn();
            }

            if (actualTurn == Turn.player)
            {
                CharacterBehaviour.instance.hasMoved = false;
            }
        }
    }
}
