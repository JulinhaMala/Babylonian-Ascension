using UnityEngine;

public class GridStats : MonoBehaviour {

    public int Visited = -1;
    public int X = 0;
    public int Y = 0;
    public int Z = 0;
    public bool walkable;
    public bool occupied;

    public void IsOccupied()
    {
        occupied = true;
    }

    public void LeftSquare()
    {
        occupied = false;
    }
}
