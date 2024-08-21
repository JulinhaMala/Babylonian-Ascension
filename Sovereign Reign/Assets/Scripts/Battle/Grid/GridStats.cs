using UnityEngine;

public class GridStats : MonoBehaviour {

    public int Visited = -1;
    public int X = 0;
    public int Y = 0;
    public bool walkable;

    public void MoveToPosition()
    {
        // get the player on the field
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            player.GetComponent<CharacterBehaviour>().MoveToPosition(X, Y);
        }
    }
}
